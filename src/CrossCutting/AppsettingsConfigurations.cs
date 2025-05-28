using Fatec.Store.User.Infrastructure.CrossCutting.v1.Models;

namespace Fatec.Store.User.Infrastructure.CrossCutting
{
    public class AppsettingsConfigurations
    {
        public JwtConfiguration JwtConfiguration { get; set; }

        public RedisConfiguration RedisConfiguration { get; set; }

        public EmailConfiguration EmailConfiguration { get; set; }

        public ServiceClient ServiceClients { get; set; }

        public string Database { get; set; }
    }
}