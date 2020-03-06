using Microsoft.EntityFrameworkCore.Migrations;

namespace FlatMatchApp.Data.Migrations
{
    public partial class AddedDisplaySettingsForModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2aab83c1-92ff-44d6-af5b-0cd1d30cb8ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3fcbf74-7a3c-4b8b-ac12-a175c7925bca");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StreetName = table.Column<string>(nullable: false),
                    ApartmentNumber = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Exists = table.Column<bool>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activities = table.Column<string>(nullable: true),
                    SquareFootage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    NumberBedrooms = table.Column<int>(nullable: false),
                    isAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Renters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Renters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Renters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leaseholders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaseholders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaseholders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leaseholders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f851d025-4f8f-4488-8ec4-dafa9c3bbe4f", "2459ff98-dc95-4c40-93b5-a65fcca26b7f", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f63eb1e-a951-4967-87a8-e28601d2f358", "3120750e-081b-440f-9c82-2dae7184280e", "Leaseholder", "LEASEHOLDER" });

            migrationBuilder.CreateIndex(
                name: "IX_Leaseholders_AddressId",
                table: "Leaseholders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaseholders_UserId",
                table: "Leaseholders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Renters_UserId",
                table: "Renters",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaseholders");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Renters");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f63eb1e-a951-4967-87a8-e28601d2f358");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f851d025-4f8f-4488-8ec4-dafa9c3bbe4f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3fcbf74-7a3c-4b8b-ac12-a175c7925bca", "85184239-1cfb-49b8-9721-a4e834c17e8f", "Renter", "RENTER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2aab83c1-92ff-44d6-af5b-0cd1d30cb8ce", "e92cb027-9796-4f5e-b1a5-2be356790261", "Leaseholder", "LEASEHOLDER" });
        }
    }
}
