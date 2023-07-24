using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class hewt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "cookies_policy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    headTitleTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headTitleENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cookies_policy", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "f98560db-e891-4dbd-b332-57e41ffe1a39", "a9b4ef0d-6567-44c7-94f6-d9b46d6cfc63", "Admin", "Admin", "Admin", new DateTime(2023, 7, 24, 18, 44, 27, 508, DateTimeKind.Utc).AddTicks(6739), new DateTime(2023, 7, 24, 18, 44, 27, 508, DateTimeKind.Utc).AddTicks(6742) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "f87771ff-d887-423c-b0cf-4c28a957a6b8", 0, null, null, "a8312460-1918-4f43-b4d9-8621fa30d632", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELrTkVTur9XLdA4xMFqQjTjrUyglGy14joiSNyepJ1rKbYQ7PLLYNLplyI8BYsR4lA==", null, false, null, null, "6224fbb4-19e0-4cc5-be8f-40e0bf1bed6b", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f98560db-e891-4dbd-b332-57e41ffe1a39", "f87771ff-d887-423c-b0cf-4c28a957a6b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cookies_policy");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f98560db-e891-4dbd-b332-57e41ffe1a39", "f87771ff-d887-423c-b0cf-4c28a957a6b8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98560db-e891-4dbd-b332-57e41ffe1a39");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f87771ff-d887-423c-b0cf-4c28a957a6b8");

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
    }
}
