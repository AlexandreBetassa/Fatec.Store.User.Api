using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Application.v1.Enums;
using Fatec.Store.User.Domain.Interfaces.v1.DomainServices;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Domain.Interfaces.v1.Services;
using Fatec.Store.User.Domain.Models.v1.Cache;
using Fatec.Store.User.Infrastructure.CrossCutting;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.User.Application.v1.Commands.Notification.SendEmail
{
    public class SendEmailCommandHandler : BaseCommandHandler<SendEmailCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordServices _passwordService;
        private readonly IEmailServiceClient _emailService;
        private readonly IEnumerable<EmailTemplates> _emailTemplates;

        public SendEmailCommandHandler(
        AppsettingsConfigurations appsettingsConfigurations,
        ILoggerFactory loggerFactory,
        IMapper mapper,
        IHttpContextAccessor httpContext,
        IUserRepository userRepository,
        IPasswordServices passwordServices,
        IEmailServiceClient emailService) : base(loggerFactory.CreateLogger<SendEmailCommandHandler>(), mapper, httpContext)
        {
            _userRepository = userRepository;
            _passwordService = passwordServices;
            _emailService = emailService;
            _emailTemplates = appsettingsConfigurations.EmailConfiguration.EmailTemplates;
        }


        public override async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailOrUsernameAsync(request.Email)
                    ?? throw new NotFoundException("Usuário não localizado!!!");

                var emailTemplate = _emailTemplates.FirstOrDefault(x => x.Type.Equals(request.Flow.ToString()));

                //TODO: melhorar com pattern Strategy
                var recoveryCode = GenerateRecoveryCode();
                var body = FormatBodyEmail(request, emailTemplate, recoveryCode);
                await _passwordService.PersistCacheRecoveryPassword(new RecoveryPasswordCache(request.Email, recoveryCode, user.Login.Id));

                await _emailService.SendEmailAsync(
                    toEmail: request.Email,
                    subject: emailTemplate?.Subject ?? string.Empty,
                    body: body);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(SendEmailCommandHandler)}.{nameof(Handle)}");

                throw;
            }
        }

        private string FormatBodyEmail(SendEmailCommand request, EmailTemplates? emailTemplate, string recoveryCode) =>
            request.Flow switch
            {
                TypeEmailEnum.RecoveryPassword => string.Format(emailTemplate.Body, recoveryCode),
                TypeEmailEnum.UpdatePassword => string.Format(emailTemplate.Body, recoveryCode),
                TypeEmailEnum.DeactivateAccount => emailTemplate?.Body ?? string.Empty,
                _ => string.Empty
            };


        private static string GenerateRecoveryCode() =>
            Random.Shared.Next(0, 999999).ToString("000000");
    }
}