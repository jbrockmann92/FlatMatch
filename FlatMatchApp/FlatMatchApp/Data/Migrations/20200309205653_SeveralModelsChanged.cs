using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class SeveralModelsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c60a05ba-c96f-4058-bd53-2ff2291c9e97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e996fae3-25fe-4172-ac87-8014fc64bb8a");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Properties",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9830d920-b90a-4870-9112-162e914b90ae", "f08db7e9-0e87-4dde-9c32-40e2c07f1d0d", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49637f89-313a-45b7-9241-d6c9a2334e95", "6feb4856-6b73-4dc9-a5e0-1d77af5e13f8", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49637f89-313a-45b7-9241-d6c9a2334e95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9830d920-b90a-4870-9112-162e914b90ae");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e996fae3-25fe-4172-ac87-8014fc64bb8a", "3c4f515b-c65d-4885-bfec-7a81906f3435", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c60a05ba-c96f-4058-bd53-2ff2291c9e97", "42f597c9-8dbd-441a-9d90-a70e59074436", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
