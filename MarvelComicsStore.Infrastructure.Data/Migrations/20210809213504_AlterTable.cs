using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelComicsStore.Infrastructure.Data.Migrations
{
    public partial class AlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Checkout",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TotalDiscount",
                table: "Checkout");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalDiscount",
                table: "Checkout",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Checkout",
                columns: new[] { "Id", "Coupon", "TotalDiscount", "TotalPrice" },
                values: new object[] { 1, "", 0m, 0m });
        }
    }
}
