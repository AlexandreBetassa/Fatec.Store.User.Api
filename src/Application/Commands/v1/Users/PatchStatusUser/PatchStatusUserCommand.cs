using MediatR;

namespace Fatec.Store.User.Application.Commands.v1.Users.PatchStatusUser
{
    public class PatchStatusUserCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}