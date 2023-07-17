using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class editepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81ff0490-26a5-45ca-9c7e-8b7af71bb286", "4268b6aa-27f5-42d8-a273-8e0f570e9356" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81ff0490-26a5-45ca-9c7e-8b7af71bb286");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4268b6aa-27f5-42d8-a273-8e0f570e9356");

            migrationBuilder.RenameColumn(
                name: "Image_List_Path",
                table: "ProjectRefs",
                newName: "Folder_Path");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "574ec2c6-edbf-4b56-a591-32dbbe6ecb1b", "Admin", "Admin", "Admin", new DateTime(2023, 7, 14, 10, 43, 38, 903, DateTimeKind.Utc).AddTicks(4333), new DateTime(2023, 7, 14, 10, 43, 38, 903, DateTimeKind.Utc).AddTicks(4337) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "c2f461d5-d9b0-4898-ad1a-0410d4811d45", 0, null, null, "3227bbcf-e7dc-4f25-9231-bee98d8b134a", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEN3r1EWBuQ8Mi5hOjZWBvXvby1Iv3n8OqkSur72Odm6YSyrn8whHM7uyxhErC/vE9A==", null, false, null, null, "842dbce0-b605-4713-be64-74df1501ed1b", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "c2f461d5-d9b0-4898-ad1a-0410d4811d45" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "c2f461d5-d9b0-4898-ad1a-0410d4811d45" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a15d21-654b-44f3-b128-100a61111c6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f461d5-d9b0-4898-ad1a-0410d4811d45");

            migrationBuilder.RenameColumn(
                name: "Folder_Path",
                table: "ProjectRefs",
                newName: "Image_List_Path");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "81ff0490-26a5-45ca-9c7e-8b7af71bb286", "c831af5c-0968-4034-b0a1-660904a77b01", "Admin", "Admin", "Admin", new DateTime(2023, 7, 14, 3, 41, 31, 260, DateTimeKind.Utc).AddTicks(2437), new DateTime(2023, 7, 14, 3, 41, 31, 260, DateTimeKind.Utc).AddTicks(2440) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "4268b6aa-27f5-42d8-a273-8e0f570e9356", 0, null, null, "b56524d5-5827-40cb-a04b-66f65b14067e", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEIt1T38vx9WrlEQxVwCZjcGPBdP8TRg/9m69RTh8r1FIRrZljQp1rXHCY6dho4CeEg==", null, false, null, null, "4cab11eb-4976-4b31-a541-9eacf0b18021", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81ff0490-26a5-45ca-9c7e-8b7af71bb286", "4268b6aa-27f5-42d8-a273-8e0f570e9356" });
        }
    }
}
