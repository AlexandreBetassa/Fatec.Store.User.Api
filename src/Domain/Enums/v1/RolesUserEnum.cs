using System.ComponentModel;

namespace Fatec.Store.User.Domain.Enums.v1
{
    public enum RolesUserEnum
    {
        [Description("Admin")]
        All,

        [Description("User")]
        Admin,

        [Description("User")]
        User
    }
}