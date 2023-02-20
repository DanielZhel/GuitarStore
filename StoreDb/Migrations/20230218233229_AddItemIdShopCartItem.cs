using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddItemIdShopCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ShopCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ShopCartItems");
        }
    }
}
