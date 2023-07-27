using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smart_Solution_Categorys");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "41ea0e9f-80c5-4b4f-93eb-329aa71b016a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37e3ef02-4164-4dd6-be65-17bdf3ff595e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41ea0e9f-80c5-4b4f-93eb-329aa71b016a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "ed754098-5f73-41d6-9e48-9bf63788cb7c", "555930c6-5494-4fd9-94b0-f20960f8922d", "Admin", "Admin", "Admin", new DateTime(2023, 7, 26, 10, 3, 52, 273, DateTimeKind.Utc).AddTicks(9677), new DateTime(2023, 7, 26, 10, 3, 52, 273, DateTimeKind.Utc).AddTicks(9680) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "367ef6da-c83f-4ec3-b565-e09eb87c501a", 0, null, null, "b8360bf3-9d67-4c88-8eea-c51a33143377", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEN2kowuUCxcoj1DiA2tLf4k43SqImrak9CNCXvczUmAHt08OlKlTmKtQuxhn5TpK5g==", null, false, null, null, "49f95f09-7a26-432a-9c51-aefbfc7f4754", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ed754098-5f73-41d6-9e48-9bf63788cb7c", "367ef6da-c83f-4ec3-b565-e09eb87c501a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ed754098-5f73-41d6-9e48-9bf63788cb7c", "367ef6da-c83f-4ec3-b565-e09eb87c501a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed754098-5f73-41d6-9e48-9bf63788cb7c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "367ef6da-c83f-4ec3-b565-e09eb87c501a");

            migrationBuilder.CreateTable(
                name: "Smart_Solution_Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solution_Categorys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "7d4c2cac-e1d5-4e32-9d12-fa86183e023e", "Admin", "Admin", "Admin", new DateTime(2023, 7, 26, 2, 51, 19, 537, DateTimeKind.Utc).AddTicks(2384), new DateTime(2023, 7, 26, 2, 51, 19, 537, DateTimeKind.Utc).AddTicks(2388) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "41ea0e9f-80c5-4b4f-93eb-329aa71b016a", 0, null, null, "59b48d95-2b57-4bd1-a2e5-a33f4a2fbedc", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEHPnsHiOZMT1Cgh2k1BW4Pbi7AxVXayfOuzt0Szwkvq6OiqDdr3XRhUD7ViB1cnkOw==", null, false, null, null, "32c136f5-eeb2-456e-9654-b997da83dd5e", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "41ea0e9f-80c5-4b4f-93eb-329aa71b016a" });
        }
    }
}
