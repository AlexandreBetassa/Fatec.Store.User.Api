using Fatec.Store.Framework.Core.Bases.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fatec.Store.User.Domain.Entities.v1
{
    [Index("UserName", IsUnique = true)]
    [Index("Email", IsUnique = true)]
    public class Login : BaseEntity
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}