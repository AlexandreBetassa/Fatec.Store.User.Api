using AutoMapper;
using Fatec.Store.User.Domain.Models.v1.Users;
using UserAccount = Fatec.Store.User.Domain.Entities.v1.User;

namespace Fatec.Store.User.Application.Queries.v1.GetAllUsersAdmin
{
    public class GetAllUsersAdminQueryProfile : Profile
    {
        public GetAllUsersAdminQueryProfile()
        {
            CreateMap<UserAccount, GetUserQueryData>(MemberList.None)
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Login.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Login.Email));

            CreateMap<Name, NameResponse>(MemberList.None);
        }
    }
}