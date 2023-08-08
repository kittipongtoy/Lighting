using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4687bb00-5131-440c-9998-65b4b09b60b6", "d4fdbac1-0329-4572-aefe-0bd65b02c039" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4687bb00-5131-440c-9998-65b4b09b60b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d4fdbac1-0329-4572-aefe-0bd65b02c039");

            migrationBuilder.RenameColumn(
                name: "YouTube_Url",
                table: "Contacts",
                newName: "YouTube_Url_TH");

            migrationBuilder.AddColumn<string>(
                name: "YouTube_Url_EN",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "f19c8485-bd2c-498c-8ee8-1cf25869fbdf", "8f293bef-8452-4e91-a7d8-866430eca2a0", "Admin", "Admin", "Admin", new DateTime(2023, 8, 8, 3, 47, 52, 693, DateTimeKind.Utc).AddTicks(6918), new DateTime(2023, 8, 8, 3, 47, 52, 693, DateTimeKind.Utc).AddTicks(6921) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "7fef94ba-1de1-4880-bed2-a71713f7e550", 0, null, null, "b9c5149f-a896-4899-aca5-65c693f02b40", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEMF2zUpMDc0ak9RyMkm8mfmwZs04lNkLGUsKZEtl+j193IhbNZRYwgPfYUitDYP4Ug==", null, false, null, null, "9edb7490-7152-46ff-b01a-77262d93b0dc", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f19c8485-bd2c-498c-8ee8-1cf25869fbdf", "7fef94ba-1de1-4880-bed2-a71713f7e550" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f19c8485-bd2c-498c-8ee8-1cf25869fbdf", "7fef94ba-1de1-4880-bed2-a71713f7e550" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f19c8485-bd2c-498c-8ee8-1cf25869fbdf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fef94ba-1de1-4880-bed2-a71713f7e550");

            migrationBuilder.DropColumn(
                name: "YouTube_Url_EN",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "YouTube_Url_TH",
                table: "Contacts",
                newName: "YouTube_Url");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "4687bb00-5131-440c-9998-65b4b09b60b6", "f78ae16b-bc1c-4955-945e-685da20e6de0", "Admin", "Admin", "Admin", new DateTime(2023, 8, 8, 2, 31, 13, 734, DateTimeKind.Utc).AddTicks(5504), new DateTime(2023, 8, 8, 2, 31, 13, 734, DateTimeKind.Utc).AddTicks(5512) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "d4fdbac1-0329-4572-aefe-0bd65b02c039", 0, null, null, "990495fb-9fa0-4de4-b586-7573f5315c0f", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEBoena5Zh5uDVee9KYhdGMDLDQoxuL1S+D9lJT7U4+eKpbrmhAprJzJ3frsZjqPv0Q==", null, false, null, null, "b2f12cfa-bfbf-437c-8900-bea7366255a8", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4687bb00-5131-440c-9998-65b4b09b60b6", "d4fdbac1-0329-4572-aefe-0bd65b02c039" });
        }
    }
}
