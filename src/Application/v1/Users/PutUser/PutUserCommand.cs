using Fatec.Store.User.Domain.Enums.v1;
using Fatec.Store.User.Domain.Models.v1.Users;
using MediatR;
using System.Text.Json.Serialization;

namespace Fatec.Store.User.Application.v1.Users.PutUser
{
    public class PutUserCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int? Id { get; set; }

        public Name Name { get; set; }

        public PutUserLoginCommand Login { get; set; }

        public string Cpf { get; set; }

        public DateTime Birthday { get; set; }

        public RolesUserEnum Role { get; set; }
    }

    public class PutUserLoginCommand
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}