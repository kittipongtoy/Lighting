using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class xxeeg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrivacyPolicies",
                table: "PrivacyPolicies");

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

            migrationBuilder.RenameTable(
                name: "PrivacyPolicies",
                newName: "privacy_Policys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_privacy_Policys",
                table: "privacy_Policys",
                column: "id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_privacy_Policys",
                table: "privacy_Policys");

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

            migrationBuilder.RenameTable(
                name: "privacy_Policys",
                newName: "PrivacyPolicies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrivacyPolicies",
                table: "PrivacyPolicies",
                column: "id");

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
    }
}
