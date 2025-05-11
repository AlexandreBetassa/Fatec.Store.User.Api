using Fatec.Store.User.Domain.Enums.v1;
using Fatec.Store.User.Domain.Models.v1.Users;

namespace Fatec.Store.User.Application.Queries.v1.GetUserById
{
    public class GetUserByIdQueryResponse
    {
        public Name Name { get; set; }

        public LoginResponse Login { get; set; }

        public string Cpf { get; set; }

        public RolesUserEnum Role { get; set; }

        public DateTime Birthday { get; set; }

        public bool Status { get; set; }
    }

    public class NameResponse
    {
        public string Name { get; set; }

        public string Last { get; set; }
    }

    public class LoginResponse
    {
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}