using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Fatec.Store.User.Application.v1.Commands.Users.PatchStatusUser
{
    public class PatchStatusUserCommandHandler
        : BaseCommandHandler<PatchStatusUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public PatchStatusUserCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IUserRepository userRepository,
            IHttpContextAccessor contextAccessor)
            : base(loggerFactory.CreateLogger<PatchStatusUserCommandHandler>(), mapper, contextAccessor)
        {
            _userRepository = userRepository;
        }

        public override async Task<Unit> Handle(PatchStatusUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id is 0)
                    throw new InvalidUserException(HttpStatusCode.BadRequest, "Dados do usuário inválido.");

                var user = await _userRepository.GetByIdAsync(request.Id)
                    ?? throw new Exception("Usuário não localizado!!!");

                user.ChangeStatus();

                await _userRepository.PatchAsync(request.Id, x => x.SetProperty(x => x.Status, user.Status));
                await _userRepository.SaveChangesAsync();

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{handle}.{method}", nameof(PatchStatusUserCommandHandler), nameof(Handle));

                throw new InternalErrorException();
            }
        }
    }
}