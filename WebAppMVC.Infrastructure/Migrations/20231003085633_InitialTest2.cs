using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Ingredients_ItemIngredientsId",
                table: "ItemIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients");

            migrationBuilder.RenameColumn(
                name: "ItemIngredientsId",
                table: "ItemIngredients",
                newName: "IngredientId");

            migrationBuilder.AlterColumn<float>(
                name: "SugarContent",
                table: "Items",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ItemIngredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DirectPersonAddressEmail",
                table: "CustomerContactInformactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DirectPhoneNumber",
                table: "CustomerContactInformactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients",
                columns: new[] { "Id", "ItemRef" });

            migrationBuilder.CreateIndex(
                name: "IX_ItemIngredients_IngredientId",
                table: "ItemIngredients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ItemIngredients_IngredientId",
                table: "ItemIngredients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemIngredients");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DirectPersonAddressEmail",
                table: "CustomerContactInformactions");

            migrationBuilder.DropColumn(
                name: "DirectPhoneNumber",
                table: "CustomerContactInformactions");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "ItemIngredients",
                newName: "ItemIngredientsId");

            migrationBuilder.AlterColumn<int>(
                name: "SugarContent",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients",
                columns: new[] { "ItemIngredientsId", "ItemRef" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Ingredients_ItemIngredientsId",
                table: "ItemIngredients",
                column: "ItemIngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
