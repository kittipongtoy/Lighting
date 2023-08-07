using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "d7e182e9-b59d-48bb-80c4-b048b7593e6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1efcf8-35d2-48c4-8a60-cd415ccc7490");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7e182e9-b59d-48bb-80c4-b048b7593e6a");

            migrationBuilder.AlterColumn<string>(
                name: "File_Path",
                table: "Downloads",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Image_Path_Nav",
                table: "Category_Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "ab08e993-6b45-4cf1-a991-93e0e72236da", "4af915a8-99fa-4530-a4dc-c4a921b12e1a", "Admin", "Admin", "Admin", new DateTime(2023, 8, 7, 10, 11, 29, 50, DateTimeKind.Utc).AddTicks(7297), new DateTime(2023, 8, 7, 10, 11, 29, 50, DateTimeKind.Utc).AddTicks(7301) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "2fb076bb-619e-46be-bcc2-05e43ca8cdb2", 0, null, null, "85f7c341-2cba-4310-9053-c2efd78ebc98", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEDttfcHBxGEt10wqApSVVXiqTH9BPABzy5oB3LvnrpsizsnBlVrljWUMmpTozDM2lw==", null, false, null, null, "dc66fb0a-022f-424a-b36f-83e7714b63ca", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab08e993-6b45-4cf1-a991-93e0e72236da", "2fb076bb-619e-46be-bcc2-05e43ca8cdb2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab08e993-6b45-4cf1-a991-93e0e72236da", "2fb076bb-619e-46be-bcc2-05e43ca8cdb2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab08e993-6b45-4cf1-a991-93e0e72236da");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fb076bb-619e-46be-bcc2-05e43ca8cdb2");

            migrationBuilder.DropColumn(
                name: "Image_Path_Nav",
                table: "Category_Projects");

            migrationBuilder.AlterColumn<string>(
                name: "File_Path",
                table: "Downloads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "bd58d2ba-5800-4c5f-abbf-57b20cb2b627", "Admin", "Admin", "Admin", new DateTime(2023, 8, 6, 14, 48, 29, 996, DateTimeKind.Utc).AddTicks(891), new DateTime(2023, 8, 6, 14, 48, 29, 996, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "d7e182e9-b59d-48bb-80c4-b048b7593e6a", 0, null, null, "606c05e6-aa5c-4f59-93bc-826e2793d73d", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELC0rcDuW0PK5PENYOgkXI75JCEOUzD+4xZfqBpSgg0AYnCiHvFc4s6rLOCb4ccnwg==", null, false, null, null, "46694da2-4a43-4f69-a223-a2d6162b86a7", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "d7e182e9-b59d-48bb-80c4-b048b7593e6a" });
        }
    }
}
