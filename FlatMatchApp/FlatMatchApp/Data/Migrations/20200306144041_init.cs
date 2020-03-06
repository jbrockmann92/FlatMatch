using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "039b3334-bddb-4c99-a1f7-17ac90f7d210");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1512cc11-502b-4bbe-9cd9-89092024d962");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3fcbf74-7a3c-4b8b-ac12-a175c7925bca", "85184239-1cfb-49b8-9721-a4e834c17e8f", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2aab83c1-92ff-44d6-af5b-0cd1d30cb8ce", "e92cb027-9796-4f5e-b1a5-2be356790261", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aab83c1-92ff-44d6-af5b-0cd1d30cb8ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3fcbf74-7a3c-4b8b-ac12-a175c7925bca");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1512cc11-502b-4bbe-9cd9-89092024d962", "ea30d50b-f7a7-40ce-bd3f-260187d57e92", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "039b3334-bddb-4c99-a1f7-17ac90f7d210", "d23adfbc-01c6-4637-b941-4dd25886c489", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
