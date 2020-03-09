using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Migrations
{
    public partial class ChangedInitializedPreferenceValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "449545d6-5e45-4f72-b6e2-1861ed6702dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5af5080d-07a0-44e3-bec6-192c6384ec24");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a611d9f-a5c9-4aea-ad74-52f0281c3303", "3884ce05-7ff7-4c7e-b823-963de8325092", "Renter", "RENTER" },
                    { "15f68f28-42a1-443e-a451-80e876960c66", "169d9bc1-9b26-4ecb-8fe6-ad9129417cb5", "Leaseholder", "LEASEHOLDER" }
                });

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Smoking");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Alcohol");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Partying");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "WasherAndDryer");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Cleanliness");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "SoundLevel");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "AC");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Patio");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Yard");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Pool");

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Gym" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15f68f28-42a1-443e-a451-80e876960c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a611d9f-a5c9-4aea-ad74-52f0281c3303");

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5af5080d-07a0-44e3-bec6-192c6384ec24", "b9823c69-1052-4b9d-bb8f-25c0261d3204", "Renter", "RENTER" },
                    { "449545d6-5e45-4f72-b6e2-1861ed6702dc", "a254c65b-698d-4163-9f15-82d7d227f70b", "Leaseholder", "LEASEHOLDER" }
                });

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Activity");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Smoking");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Drinking");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Bedtime");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Noise Level");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Washer/Dryer");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "GymInBuilding");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Cleanliness");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Food");

            migrationBuilder.UpdateData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: 10,
                column: "Name",
                value: "Extravert/Introvert");
        }
    }
}
