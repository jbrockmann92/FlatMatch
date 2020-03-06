using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class AddedAddressToProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaseholders_Addresses_AddressId",
                table: "Leaseholders");

            migrationBuilder.DropIndex(
                name: "IX_Leaseholders_AddressId",
                table: "Leaseholders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c478f07-33af-445f-b9dd-810fb24448b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a84e567a-c166-4640-b98c-390fd5258010");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Leaseholders");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Properties",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1d2b59bc-bc4a-429f-a65f-b43be61b1e4d", "85755684-53e5-4223-bdda-029347445527", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76145f2a-a417-4988-80da-9d71cc92cbfd", "55de2de1-b2a1-42ef-8860-8a03c5792ec2", "Leaseholder", "LEASEHOLDER" });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaseholders_PropertyId",
                table: "Leaseholders",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaseholders_Properties_PropertyId",
                table: "Leaseholders",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaseholders_Properties_PropertyId",
                table: "Leaseholders");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_AddressId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Leaseholders_PropertyId",
                table: "Leaseholders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d2b59bc-bc4a-429f-a65f-b43be61b1e4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76145f2a-a417-4988-80da-9d71cc92cbfd");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Leaseholders",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a84e567a-c166-4640-b98c-390fd5258010", "bd90672e-a553-4362-be74-ef00d088034a", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c478f07-33af-445f-b9dd-810fb24448b4", "26713184-d0e0-40d0-a3ce-1798bb709343", "Leaseholder", "LEASEHOLDER" });

            migrationBuilder.CreateIndex(
                name: "IX_Leaseholders_AddressId",
                table: "Leaseholders",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaseholders_Addresses_AddressId",
                table: "Leaseholders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
