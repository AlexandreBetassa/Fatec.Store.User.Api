using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.User.Application.v1.Commands.Users.PutUser
{
    public class PutUserCommandHandler : BaseCommandHandler<PutUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public PutUserCommandHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IUserRepository userRepository)
            : base(loggerFactory.CreateLogger<PutUserCommandHandler>(), mapper, httpContext)
        {
            _userRepository = userRepository;
        }

        public override async Task<Unit> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var oldUser = await _userRepository.GetByIdAsync(request?.Id ?? 0) ??
                    throw new NotFoundException("Usuário não localizado !!!");

                var newUser = Mapper.Map(request, oldUser);

                if (IsEmailChanged(oldUser, newUser))
                    newUser.Login.Email = oldUser.Login.Email;

                await _userRepository.UpdateAsync(newUser);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{handler}.{method}", nameof(PutUserCommandHandler), nameof(Handle));

                throw;
            }
        }

        private static bool IsEmailChanged(Domain.Entities.v1.User oldUser, Domain.Entities.v1.User newUser) =>
             oldUser.Login.Email.Equals(newUser.Login.Email);
    }
}
