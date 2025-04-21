using Fatec.Store.Framework.Core.Bases.v1.Entities;
using Fatec.Store.User.Domain.Enums.v1;
using Fatec.Store.User.Domain.Models.v1.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Fatec.Store.User.Domain.Entities.v1
{
    [Index("Cpf", IsUnique = true)]
    public class User : BaseEntity
    {
        public Name Name { get; set; }

        public Login Login { get; set; }

        public string Cpf { get; set; }

        public DateTime Birthday { get; set; }

        public RolesUserEnum Role { get; set; }

        public void ChangeStatus() => Status = !Status;
    }
}