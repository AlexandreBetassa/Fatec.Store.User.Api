using AutoMapper;
using Fatec.Store.Framework.Core.Bases.v1.CommandHandler;
using Fatec.Store.User.Domain.Enums.v1;
using Fatec.Store.User.Domain.Interfaces.v1.Repositories;
using Fatec.Store.User.Infrastructure.CrossCutting.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fatec.Store.User.Application.Queries.v1.GetAllUsersAdmin
{
    public class GetAllUsersAdminQueryHandler(
        ILoggerFactory loggerFactory,
        IMapper mapper,
        IUserRepository userRepository,
        IHttpContextAccessor contextAccessor)
        : BaseCommandHandler<GetAllUsersAdminQuery, GetAllUsersAdminQueryResponse>(loggerFactory.CreateLogger<GetAllUsersAdminQueryHandler>(), mapper, contextAccessor)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public override async Task<GetAllUsersAdminQueryResponse> Handle(GetAllUsersAdminQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usersData = await _userRepository.GetAllUserAsync();

                usersData = usersData.Where(user => user?.Role.Equals(RolesUserEnum.Admin) ?? false);

                var users = Mapper.Map<IEnumerable<GetUserQueryData>>(usersData);

                return new(users);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{handler}.{method}", nameof(GetAllUsersAdminQueryHandler), nameof(Handle));

                throw new InternalErrorException();
            }
        }
    }
}