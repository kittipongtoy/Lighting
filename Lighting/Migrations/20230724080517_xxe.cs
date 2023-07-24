using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class xxe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08140a31-c341-4707-9b2d-b9729c066dde", "26dfeef5-9d84-4670-9279-f30bc61bbffa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08140a31-c341-4707-9b2d-b9729c066dde");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26dfeef5-9d84-4670-9279-f30bc61bbffa");

            migrationBuilder.CreateTable(
                name: "PrivacyPolicies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<DateTime>(type: "datetime2", nullable: true),
                    typeOfPolicy_id = table.Column<int>(type: "int", nullable: true),
                    typeOfPolicy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsTH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    detailsENG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active_status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacyPolicies", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "a1bcdf36-b6e6-4e87-8575-332c2c4758fd", "144fc80b-836a-4447-b19e-3be3ff4fa633", "Admin", "Admin", "Admin", new DateTime(2023, 7, 24, 8, 5, 17, 171, DateTimeKind.Utc).AddTicks(1378), new DateTime(2023, 7, 24, 8, 5, 17, 171, DateTimeKind.Utc).AddTicks(1382) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "a4f18587-f050-4e26-9145-7ac28b7de63e", 0, null, null, "ae3fba9c-721e-4c7f-a899-329d0b263d06", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEL53IK8uyBeTuZl4SBSrs3P7vnT2PkfQB1Q6qPpc9aYzLZ0/xHHgJV1M2n7GhhAUjA==", null, false, null, null, "9ff262a5-5a72-40cf-a81c-41fc0cf57b78", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a1bcdf36-b6e6-4e87-8575-332c2c4758fd", "a4f18587-f050-4e26-9145-7ac28b7de63e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivacyPolicies");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1bcdf36-b6e6-4e87-8575-332c2c4758fd", "a4f18587-f050-4e26-9145-7ac28b7de63e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1bcdf36-b6e6-4e87-8575-332c2c4758fd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a4f18587-f050-4e26-9145-7ac28b7de63e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "08140a31-c341-4707-9b2d-b9729c066dde", "20ac1a76-c0a0-4ac1-afad-2306702ef9ca", "Admin", "Admin", "Admin", new DateTime(2023, 7, 24, 7, 54, 14, 141, DateTimeKind.Utc).AddTicks(8291), new DateTime(2023, 7, 24, 7, 54, 14, 141, DateTimeKind.Utc).AddTicks(8328) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "26dfeef5-9d84-4670-9279-f30bc61bbffa", 0, null, null, "b15be783-b1e1-4dd0-b4d6-739c75881605", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEO53iq580pfhoNkVY7w6e7KXuT2s7wmUatJQDZC1xAevP2TwAt0mScr3LV7fGJgXfQ==", null, false, null, null, "ec68dbb4-7c17-4db4-bb84-33aa4e52b3eb", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "08140a31-c341-4707-9b2d-b9729c066dde", "26dfeef5-9d84-4670-9279-f30bc61bbffa" });
        }
    }
}
