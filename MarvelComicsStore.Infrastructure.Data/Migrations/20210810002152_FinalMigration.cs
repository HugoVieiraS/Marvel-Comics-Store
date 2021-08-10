using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvelComicsStore.Infrastructure.Data.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Checkout",
                columns: new[] { "Id", "Coupon", "TotalPrice" },
                values: new object[] { 1, "R00002", 4.25m });

            migrationBuilder.InsertData(
                table: "PurchasedItem",
                columns: new[] { "Id", "CheckoutId", "Price", "Rare", "Title", "Unity" },
                values: new object[] { 1, 1, 4.25m, false, "Teste", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchasedItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Checkout",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
