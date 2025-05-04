using AutoMapper;
using Fatec.Store.User.Domain.Entities.v1;

namespace Fatec.Store.User.Application.Commands.v1.Users.PutUser
{
    public class PutUserCommandProfile : Profile
    {
        public PutUserCommandProfile()
        {
            CreateMap<PutUserCommand, Domain.Entities.v1.User>(MemberList.None);

            CreateMap<PutUserLoginCommand, Login>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}