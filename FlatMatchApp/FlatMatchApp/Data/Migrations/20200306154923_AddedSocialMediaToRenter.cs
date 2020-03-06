using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Data.Migrations
{
    public partial class AddedSocialMediaToRenter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f63eb1e-a951-4967-87a8-e28601d2f358");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f851d025-4f8f-4488-8ec4-dafa9c3bbe4f");

            migrationBuilder.AddColumn<string>(
                name: "FacebookSocial",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramSocial",
                table: "Renters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterSocial",
                table: "Renters",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "327d0555-df2e-46ce-ac87-7fdcd23a1a85", "198f1a6c-bb0e-41bb-b156-318ba625f613", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "965a4ac6-cf3a-470c-8180-bd8684968f50", "1dec57fe-9ce8-4a7c-91c3-b99aede4270f", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "327d0555-df2e-46ce-ac87-7fdcd23a1a85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "965a4ac6-cf3a-470c-8180-bd8684968f50");

            migrationBuilder.DropColumn(
                name: "FacebookSocial",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "InstagramSocial",
                table: "Renters");

            migrationBuilder.DropColumn(
                name: "TwitterSocial",
                table: "Renters");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f851d025-4f8f-4488-8ec4-dafa9c3bbe4f", "2459ff98-dc95-4c40-93b5-a65fcca26b7f", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f63eb1e-a951-4967-87a8-e28601d2f358", "3120750e-081b-440f-9c82-2dae7184280e", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
