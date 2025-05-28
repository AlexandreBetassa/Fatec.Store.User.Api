using AutoMapper;
using Fatec.Store.User.Domain.Entities.v1;

namespace Fatec.Store.User.Application.v1.Queries.GetUserById
{
    public class GetUserByIdQueryProfile : Profile
    {
        public GetUserByIdQueryProfile()
        {
            CreateMap<Domain.Entities.v1.User, GetUserByIdQueryResponse>(MemberList.None);

            CreateMap<Login, LoginResponse>(MemberList.None);
        }
    }
}
