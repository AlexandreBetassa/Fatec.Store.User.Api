using Fatec.Store.User.Domain.Interfaces.v1.Services;
using Fatec.Store.User.Domain.Models.v1.Services;
using Fatec.Store.User.Infrastructure.CrossCutting;
using Fatec.Store.User.Infrastructure.CrossCutting.v1.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Fatec.Store.User.Application.v1.ServiceClients
{
    public class CartServiceClient(HttpClient httpClient, IOptions<AppsettingsConfigurations> options) : ICartServiceClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _cartUrl = options.Value.ServiceClients.Cart;

        public async Task CreateCartAsync(CreateCartRequest request)
        {
            {
                var content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.PostAsync($"{_cartUrl}", content);

                if (!response.IsSuccessStatusCode)
                    throw new CreateCartFailedException(response.StatusCode);
            }
        }
    }
}