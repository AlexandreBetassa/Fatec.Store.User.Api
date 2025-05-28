namespace Fatec.Store.User.Domain.Models.v1.Services
{
    public class CreateCartRequest(int userId)
    {
        public int UserId { get; set; } = userId;
    }
}