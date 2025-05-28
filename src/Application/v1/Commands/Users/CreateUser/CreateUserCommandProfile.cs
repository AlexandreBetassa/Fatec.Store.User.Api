using AutoMapper;
using Fatec.Store.User.Application.Shared.Extensions;
using UserAccount = Fatec.Store.User.Domain.Entities.v1.User;

namespace Fatec.Store.User.Application.v1.Commands.Users.CreateUser
{
    public class CreateUserCommandProfile : Profile
    {
        public CreateUserCommandProfile()
        {
            CreateMap<CreateUserCommand, UserAccount>(MemberList.Source)
                .ForMember(dest => dest.Status, src => src.MapFrom(opt => true))
                .ForMember(dest => dest.Name, src => src.MapFrom(opt => opt.Name))
                .ForMember(dest => dest.Cpf, src => src.MapFrom(opt => opt.Cpf.UnformatCpf()));
        }
    }
}