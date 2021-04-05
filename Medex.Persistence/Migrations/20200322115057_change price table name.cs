using Microsoft.EntityFrameworkCore.Migrations;

namespace Medex.Persistence.Migrations
{
    public partial class changepricetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceFiles_Price_PriceId",
                table: "PriceFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceItems_Price_PriceId",
                table: "PriceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Price",
                table: "Price");

            migrationBuilder.RenameTable(
                name: "Price",
                newName: "Prices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prices",
                table: "Prices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceFiles_Prices_PriceId",
                table: "PriceFiles",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceItems_Prices_PriceId",
                table: "PriceItems",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceFiles_Prices_PriceId",
                table: "PriceFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_PriceItems_Prices_PriceId",
                table: "PriceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prices",
                table: "Prices");

            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "Price");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Price",
                table: "Price",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceFiles_Price_PriceId",
                table: "PriceFiles",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PriceItems_Price_PriceId",
                table: "PriceItems",
                column: "PriceId",
                principalTable: "Price",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
