using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginCustomer",
                table: "Customers",
                newName: "REGON");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "REGON",
                table: "Customers",
                newName: "LoginCustomer");
        }
    }
}
