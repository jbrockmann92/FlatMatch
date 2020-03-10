using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class UpdatingPreferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49637f89-313a-45b7-9241-d6c9a2334e95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9830d920-b90a-4870-9112-162e914b90ae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c78095f9-3e2a-4e50-9c59-acb9475c1b1c", "6887558e-532d-4307-af88-bdc6acccbec5", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c302911d-651e-489b-ac07-850c71244a3b", "f79dc4f4-5b33-4a46-8cab-977d9406d9da", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c302911d-651e-489b-ac07-850c71244a3b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c78095f9-3e2a-4e50-9c59-acb9475c1b1c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9830d920-b90a-4870-9112-162e914b90ae", "f08db7e9-0e87-4dde-9c32-40e2c07f1d0d", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49637f89-313a-45b7-9241-d6c9a2334e95", "6feb4856-6b73-4dc9-a5e0-1d77af5e13f8", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
