using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class adddownload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "822888e5-bfe7-4ba5-a551-85b62b77d0b0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd57ef74-02fa-4a0e-9720-c602eac28b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "822888e5-bfe7-4ba5-a551-85b62b77d0b0");

            migrationBuilder.CreateTable(
                name: "Downloads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Downloads", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "681de778-ad22-4738-8362-38a87fde5fc3", "8f55ae37-4edf-4d86-ad1f-40370b4a735b", "Admin", "Admin", "Admin", new DateTime(2023, 7, 8, 15, 22, 30, 504, DateTimeKind.Utc).AddTicks(1132), new DateTime(2023, 7, 8, 15, 22, 30, 504, DateTimeKind.Utc).AddTicks(1137) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "e4c80e5e-53ab-4130-92fd-70881f94b5e4", 0, null, null, "9a5bb3d2-9f57-411e-8acc-c07f06e5a1b3", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEPubWK1N8a4B6LJI0/1qJHXUuo5XDkbvODTQ8NlcVK/W/WQ+qSOWBWBHaVGC7Kggcg==", null, false, null, null, "583b5607-2206-4e16-8090-f4b878f1d030", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "681de778-ad22-4738-8362-38a87fde5fc3", "e4c80e5e-53ab-4130-92fd-70881f94b5e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Downloads");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "681de778-ad22-4738-8362-38a87fde5fc3", "e4c80e5e-53ab-4130-92fd-70881f94b5e4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "681de778-ad22-4738-8362-38a87fde5fc3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4c80e5e-53ab-4130-92fd-70881f94b5e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "2d49a22f-88f0-4e55-8672-dd6a85a8dc9a", "Admin", "Admin", "Admin", new DateTime(2023, 7, 7, 5, 50, 14, 778, DateTimeKind.Utc).AddTicks(4669), new DateTime(2023, 7, 7, 5, 50, 14, 778, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "822888e5-bfe7-4ba5-a551-85b62b77d0b0", 0, null, null, "e9dba9a6-7701-4c21-8c0b-2f2a64175390", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEK5PEJl2pA5uLgneLXLtVN56JQgkG9pYhchVr7zQWbjy+OItylZEvJp0RzVQS4zCvQ==", null, false, null, null, "42f3019d-b51a-43e2-b000-c3e33116c554", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "822888e5-bfe7-4ba5-a551-85b62b77d0b0" });
        }
    }
}
