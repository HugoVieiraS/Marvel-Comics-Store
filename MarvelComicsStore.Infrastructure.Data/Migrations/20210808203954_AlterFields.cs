using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelComicsStore.Infrastructure.Data.Migrations
{
    public partial class AlterFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItem_Checkout_CheckoutId",
                table: "PurchasedItem");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "PurchasedItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "Checkout",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalDiscount",
                table: "Checkout",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Checkout",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalDiscount", "TotalPrice" },
                values: new object[] { 0m, 0m });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItem_Checkout_CheckoutId",
                table: "PurchasedItem",
                column: "CheckoutId",
                principalTable: "Checkout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasedItem_Checkout_CheckoutId",
                table: "PurchasedItem");

            migrationBuilder.AlterColumn<int>(
                name: "CheckoutId",
                table: "PurchasedItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "Checkout",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<double>(
                name: "TotalDiscount",
                table: "Checkout",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.UpdateData(
                table: "Checkout",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalDiscount", "TotalPrice" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasedItem_Checkout_CheckoutId",
                table: "PurchasedItem",
                column: "CheckoutId",
                principalTable: "Checkout",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
