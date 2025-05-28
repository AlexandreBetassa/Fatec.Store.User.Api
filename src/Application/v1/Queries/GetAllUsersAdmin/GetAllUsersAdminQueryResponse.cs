namespace Fatec.Store.User.Application.v1.Queries.GetAllUsersAdmin
{
    public class GetAllUsersAdminQueryResponse(IEnumerable<GetUserQueryData> users)
    {
        public IEnumerable<GetUserQueryData> Users { get; set; } = users;
    }

    public class GetUserQueryData
    {
        public int Id { get; set; }

        public NameResponse Name { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public bool Status { get; set; }

        public string Username { get; set; }
    }

    public class NameResponse
    {
        public string First { get; set; }

        public string Last { get; set; }
    }
}