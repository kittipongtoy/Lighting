using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class addproductsubimgfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f00cb9ef-48da-4e4a-92c6-fc3cb441385e", "6ab35bea-44a6-46df-8ab2-9833409d927a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f00cb9ef-48da-4e4a-92c6-fc3cb441385e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ab35bea-44a6-46df-8ab2-9833409d927a");

            migrationBuilder.AddColumn<string>(
                name: "SUB_IMG",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "474bb950-2acc-4ada-9f3f-d79cacb47dac", "Admin", "Admin", "Admin", new DateTime(2023, 7, 22, 14, 57, 22, 993, DateTimeKind.Utc).AddTicks(613), new DateTime(2023, 7, 22, 14, 57, 22, 993, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "55565517-bb27-4454-aad0-a19560359c82", 0, null, null, "7bce3fa4-aa11-474a-940b-ab66d70de8c2", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEG+FY/9MWWdVPRxBWaQAd3W16Yeohf/tpjgdoYhlhRkl4RYfZ6coG0l094T5EkXo9A==", null, false, null, null, "93e5714d-a2bf-4db7-beb1-26ee6d8e9a28", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "55565517-bb27-4454-aad0-a19560359c82" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "55565517-bb27-4454-aad0-a19560359c82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bc216a-9943-4c54-b51d-0c0e6ad8a19f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55565517-bb27-4454-aad0-a19560359c82");

            migrationBuilder.DropColumn(
                name: "SUB_IMG",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "f00cb9ef-48da-4e4a-92c6-fc3cb441385e", "d9b62fa0-1ec3-4373-84d0-9b9b731e7d28", "Admin", "Admin", "Admin", new DateTime(2023, 7, 22, 14, 10, 42, 948, DateTimeKind.Utc).AddTicks(4950), new DateTime(2023, 7, 22, 14, 10, 42, 948, DateTimeKind.Utc).AddTicks(4960) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "6ab35bea-44a6-46df-8ab2-9833409d927a", 0, null, null, "e3d9a76e-d03c-483a-b4ab-997aad8d347f", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEFqcL85wkwQlfL60iGM8xT/bYaECeLIY5thP7zKqZeWwDfgaLhpk5/p/s4ysLKhMyg==", null, false, null, null, "1903e18a-8618-4303-85eb-e52999d3f399", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f00cb9ef-48da-4e4a-92c6-fc3cb441385e", "6ab35bea-44a6-46df-8ab2-9833409d927a" });
        }
    }
}
