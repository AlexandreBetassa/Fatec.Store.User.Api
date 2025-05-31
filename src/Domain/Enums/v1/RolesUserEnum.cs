using System.ComponentModel;

namespace Fatec.Store.User.Domain.Enums.v1
{
    public enum RolesUserEnum
    {
        [Description("Guest")]
        Guest,

        [Description("Admin")]
        All,

        [Description("User")]
        Admin,

        [Description("User")]
        User
    }
}