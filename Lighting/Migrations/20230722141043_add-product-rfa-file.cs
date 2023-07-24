using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class addproductrfafile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cf9a0bce-8fa9-4f9a-96e3-40fb7c45b33d", "856b3ef2-08e6-4342-a7aa-badefa1f940e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf9a0bce-8fa9-4f9a-96e3-40fb7c45b33d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "856b3ef2-08e6-4342-a7aa-badefa1f940e");

            migrationBuilder.AddColumn<string>(
                name: "RFA",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RFA",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "cf9a0bce-8fa9-4f9a-96e3-40fb7c45b33d", "1cf125cf-aa20-4bd9-8bc1-bb9b38d0f4ba", "Admin", "Admin", "Admin", new DateTime(2023, 7, 21, 2, 36, 12, 433, DateTimeKind.Utc).AddTicks(2665), new DateTime(2023, 7, 21, 2, 36, 12, 433, DateTimeKind.Utc).AddTicks(2668) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "856b3ef2-08e6-4342-a7aa-badefa1f940e", 0, null, null, "a740d010-0def-4c93-b25f-93ac6a9bfb6a", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEEs4RhWC33CSI38x/K3zP6olznmDYGNnOIuS0EzVbLrPx0cMEO+ULnlygI2Yj0iq3Q==", null, false, null, null, "a26c9ea1-fada-4bd1-bef5-37a2a9802075", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cf9a0bce-8fa9-4f9a-96e3-40fb7c45b33d", "856b3ef2-08e6-4342-a7aa-badefa1f940e" });
        }
    }
}
