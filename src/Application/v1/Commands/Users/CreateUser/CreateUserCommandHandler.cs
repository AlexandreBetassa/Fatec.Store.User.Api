using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Domain.Interfaces.v1.DomainServices;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using UserAccount = Fatec.Store.User.Domain.Entities.v1.User;

namespace Fatec.Store.User.Application.v1.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : BaseCommandHandler<CreateUserCommand, Unit>
    {
        private readonly IPasswordServices _passwordServices;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler
            (ILoggerFactory loggerFactory,
            IMapper mapper,
            IUserRepository userRepository,
            IPasswordServices passwordServices,
            IHttpContextAccessor contextAccessor)
            : base(loggerFactory.CreateLogger<CreateUserCommandHandler>(), mapper, contextAccessor)
        {
            _passwordServices = passwordServices;
            _userRepository = userRepository;
        }

        public override async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = Mapper.Map<UserAccount>(request);

                user.Login.Password = _passwordServices.HashPassword(user.Login, request.Login.Password);

                await _userRepository.CreateAsync(user);

                await _userRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException.Message;

                var match = Regex.Match(message, @"unique index '([^']+)'");
                var constraintName = match.Success ? match.Groups[1].Value : null;

                Logger.LogWarning(ex, $"Violação de chave única: {constraintName}");

                string userFriendlyMessage = constraintName switch
                {
                    "IX_Login_Email" => "Email já cadastrado.",
                    "IX_Login_UserName" => "Username já cadastrado.",
                    "IX_Login_Cpf" => "CPF já cadastrado.",
                    _ => "Ocorreu um erro finalizar o cadastro. Por favor tente novamente mais tarde ou contate o administrador."
                };

                throw new AlreadyExistsException(message: userFriendlyMessage);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro metodo {nameof(CreateUserCommandHandler)}.{nameof(Handle)}");

                throw new InternalErrorException();
            }
        }
    }
}