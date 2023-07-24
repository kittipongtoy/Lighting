using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class hew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "581ca5ff-ac92-4304-b653-6409c1cc10bb", "825c5f51-033f-4e9f-af4c-37a1819f58dd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "581ca5ff-ac92-4304-b653-6409c1cc10bb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "825c5f51-033f-4e9f-af4c-37a1819f58dd");

            migrationBuilder.CreateTable(
                name: "privacy_PolicyTitles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_TitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_TitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_NoticeTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    privacy_NoticeTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cctv_privacyTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cctv_privacyTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_privacy_PolicyTitles", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "46ada7ec-adb6-4d53-9e11-9d715ef856e0", "b8808a68-69ce-4a4a-89ed-c9b824a3ed2d", "Admin", "Admin", "Admin", new DateTime(2023, 7, 24, 16, 53, 31, 866, DateTimeKind.Utc).AddTicks(1317), new DateTime(2023, 7, 24, 16, 53, 31, 866, DateTimeKind.Utc).AddTicks(1322) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "d2a29d00-e03f-4433-a980-3154901158f0", 0, null, null, "e72b8477-fcd7-4a32-9a3e-dd7f9fcfb4a7", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEC3elEEtdveLWY3wDs16pCSZblg3SxhM/jXIo732TERhGwGZ0SAtOTt7NS+7Tn2sbQ==", null, false, null, null, "c187f093-a6e9-4d53-8bb1-de020dc9c735", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "46ada7ec-adb6-4d53-9e11-9d715ef856e0", "d2a29d00-e03f-4433-a980-3154901158f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "privacy_PolicyTitles");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "46ada7ec-adb6-4d53-9e11-9d715ef856e0", "d2a29d00-e03f-4433-a980-3154901158f0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46ada7ec-adb6-4d53-9e11-9d715ef856e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2a29d00-e03f-4433-a980-3154901158f0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "581ca5ff-ac92-4304-b653-6409c1cc10bb", "19efabe4-6c53-4368-ae5b-4b16b924c4b1", "Admin", "Admin", "Admin", new DateTime(2023, 7, 24, 9, 18, 11, 834, DateTimeKind.Utc).AddTicks(9524), new DateTime(2023, 7, 24, 9, 18, 11, 834, DateTimeKind.Utc).AddTicks(9527) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "825c5f51-033f-4e9f-af4c-37a1819f58dd", 0, null, null, "f04cd12a-5572-4a58-8103-1b652c6ee327", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAECuaJx/WJy0PyP06P24zbHOTe1cLAgb9RNc1cpw9gtMFRF/1Tdm3XLba7b/yP8B+jw==", null, false, null, null, "2c8b3d88-d52f-41f5-b9bc-7782fc6e7aa8", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "581ca5ff-ac92-4304-b653-6409c1cc10bb", "825c5f51-033f-4e9f-af4c-37a1819f58dd" });
        }
    }
}
