using MediatR;

namespace Fatec.Store.User.Application.v1.Users.PatchStatusUser
{
    public class PatchStatusUserCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}