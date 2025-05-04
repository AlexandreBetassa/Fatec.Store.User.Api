using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Infrastructure.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.User.Application.Queries.v1.GetUserById
{
    public class GetUserByIdQueryHandler : BaseCommandHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IHttpContextAccessor httpContext,
            IUserRepository userRepository)
            : base(loggerFactory.CreateLogger<GetUserByIdQueryHandler>(), mapper, httpContext)
        {
            _userRepository = userRepository;
        }

        public override async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Id is 0)
                    throw new BadRequestException(message: "ID do usuário inválido");

                var userData = await _userRepository.GetByIdAsync(request.Id);
                var response = Mapper.Map<GetUserByIdQueryResponse>(userData);

                return response;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{handler}.{method}", nameof(GetUserByIdQueryHandler), nameof(Handle));

                throw;
            }
        }
    }
}
