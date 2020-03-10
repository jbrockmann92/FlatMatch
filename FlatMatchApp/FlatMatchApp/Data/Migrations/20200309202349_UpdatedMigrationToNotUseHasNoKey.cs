using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class UpdatedMigrationToNotUseHasNoKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15f68f28-42a1-443e-a451-80e876960c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a611d9f-a5c9-4aea-ad74-52f0281c3303");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserPreferences",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPreferences",
                table: "UserPreferences",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e996fae3-25fe-4172-ac87-8014fc64bb8a", "3c4f515b-c65d-4885-bfec-7a81906f3435", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c60a05ba-c96f-4058-bd53-2ff2291c9e97", "42f597c9-8dbd-441a-9d90-a70e59074436", "Leaseholder", "LEASEHOLDER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPreferences",
                table: "UserPreferences");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c60a05ba-c96f-4058-bd53-2ff2291c9e97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e996fae3-25fe-4172-ac87-8014fc64bb8a");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserPreferences");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a611d9f-a5c9-4aea-ad74-52f0281c3303", "3884ce05-7ff7-4c7e-b823-963de8325092", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "15f68f28-42a1-443e-a451-80e876960c66", "169d9bc1-9b26-4ecb-8fe6-ad9129417cb5", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
