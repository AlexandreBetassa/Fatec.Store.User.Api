using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.User.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameAndEmailAsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Login",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Login",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Email",
                table: "Login",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Login_UserName",
                table: "Login",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Login_Email",
                table: "Login");

            migrationBuilder.DropIndex(
                name: "IX_Login_UserName",
                table: "Login");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
