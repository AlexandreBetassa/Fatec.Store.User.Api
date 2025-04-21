using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.User.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCpfAsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Users",
                type: "nvarchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Cpf",
                table: "Users",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Cpf",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Users");
        }
    }
}
