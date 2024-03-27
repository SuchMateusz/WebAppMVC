using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlcoholIngredients",
                table: "AlcoholIngredients");

            migrationBuilder.DropIndex(
                name: "IX_AlcoholIngredients_IngredientId",
                table: "AlcoholIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlcoholIngredients",
                table: "AlcoholIngredients",
                columns: new[] { "IngredientId", "AlcoholRef" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlcoholIngredients",
                table: "AlcoholIngredients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlcoholIngredients",
                table: "AlcoholIngredients",
                columns: new[] { "Id", "AlcoholRef" });

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholIngredients_IngredientId",
                table: "AlcoholIngredients",
                column: "IngredientId");
        }
    }
}
