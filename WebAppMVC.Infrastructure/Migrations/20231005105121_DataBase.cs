using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerContactInformactions_CustomerRef",
                table: "CustomerContactInformactions");

            migrationBuilder.RenameColumn(
                name: "PhoneNubmer",
                table: "Customers",
                newName: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformactions_CustomerRef",
                table: "CustomerContactInformactions",
                column: "CustomerRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CustomerContactInformactions_CustomerRef",
                table: "CustomerContactInformactions");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Customers",
                newName: "PhoneNubmer");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerContactInformactions_CustomerRef",
                table: "CustomerContactInformactions",
                column: "CustomerRef",
                unique: true);
        }
    }
}
