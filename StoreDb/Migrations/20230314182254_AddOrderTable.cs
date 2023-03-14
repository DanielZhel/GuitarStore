using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShopCartItems");

            migrationBuilder.RenameColumn(
                name: "ShopCartId",
                table: "ShopCartItems",
                newName: "SessionId");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShopCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_ItemId",
                table: "ShopCartItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCartItems_OrderId",
                table: "ShopCartItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Items_ItemId",
                table: "ShopCartItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShopCartItems_Orders_OrderId",
            //    table: "ShopCartItems",
            //    column: "OrderId",
            //    principalTable: "Orders",
            //    principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Items_ItemId",
                table: "ShopCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Orders_OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItems_ItemId",
                table: "ShopCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopCartItems_OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShopCartItems");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "ShopCartItems",
                newName: "ShopCartId");

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

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ShopCartItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
