using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddShopCartItemLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Items_ItemId",
                table: "ShopCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItems_ItemId",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<string>(
                name: "Descripton",
                table: "ShopCartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ShopCartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "ShopCartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModelName",
                table: "ShopCartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripton",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "ModelName",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ShopCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_ItemId",
                table: "ShopCartItems",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Items_ItemId",
                table: "ShopCartItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
