using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class updatedAddressAndRenterViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e0b9a11-c9e8-4bd7-a489-53d52786baca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "604244c1-96b2-4884-9f13-50e2d4e7d2e2");

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileUrl",
                table: "Leaseholders",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cdb4ef11-be1b-40fb-a558-a95856c0688b", "38c59e65-4a1e-4a0e-b4f7-9179121bbefb", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcfd324a-b3c7-4199-8287-6b04ec0f3fcb", "7fc11a44-af25-454b-aa68-65452531463d", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcfd324a-b3c7-4199-8287-6b04ec0f3fcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdb4ef11-be1b-40fb-a558-a95856c0688b");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "ProfileUrl",
                table: "Leaseholders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e0b9a11-c9e8-4bd7-a489-53d52786baca", "d3327043-1d08-4bf8-b3a7-5ab5324e516d", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "604244c1-96b2-4884-9f13-50e2d4e7d2e2", "53b647b8-7d56-4261-96e8-644f30f2911f", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
