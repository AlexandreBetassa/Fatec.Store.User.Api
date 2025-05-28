using Fatec.Store.User.Domain.Models.v1.Services;

namespace Fatec.Store.User.Domain.Interfaces.v1.Services
{
    public interface ICartServiceClient
    {
        Task CreateCartAsync(CreateCartRequest request);
    }
}
