using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddUserLoginOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShopCartItems_Orders_OrderId",
            //    table: "ShopCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ShopCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShopCartItems_Orders_OrderId",
            //    table: "ShopCartItems",
            //    column: "OrderId",
            //    principalTable: "Orders",
            //    principalColumn: "OrderId",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopCartItems_Orders_OrderId",
                table: "ShopCartItems");

            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "ShopCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCartItems_Orders_OrderId",
                table: "ShopCartItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
