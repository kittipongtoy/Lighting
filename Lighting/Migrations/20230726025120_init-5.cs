using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37d9f154-fa4e-41f3-b40a-2b8abdd25138", "3208a247-8509-4873-8f60-a4818596d4e2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37d9f154-fa4e-41f3-b40a-2b8abdd25138");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3208a247-8509-4873-8f60-a4818596d4e2");

            migrationBuilder.AddColumn<string>(
                name: "DetailImg",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "7d4c2cac-e1d5-4e32-9d12-fa86183e023e", "Admin", "Admin", "Admin", new DateTime(2023, 7, 26, 2, 51, 19, 537, DateTimeKind.Utc).AddTicks(2384), new DateTime(2023, 7, 26, 2, 51, 19, 537, DateTimeKind.Utc).AddTicks(2388) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "41ea0e9f-80c5-4b4f-93eb-329aa71b016a", 0, null, null, "59b48d95-2b57-4bd1-a2e5-a33f4a2fbedc", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEHPnsHiOZMT1Cgh2k1BW4Pbi7AxVXayfOuzt0Szwkvq6OiqDdr3XRhUD7ViB1cnkOw==", null, false, null, null, "32c136f5-eeb2-456e-9654-b997da83dd5e", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "41ea0e9f-80c5-4b4f-93eb-329aa71b016a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "37e3ef02-4164-4dd6-be65-17bdf3ff595e", "41ea0e9f-80c5-4b4f-93eb-329aa71b016a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37e3ef02-4164-4dd6-be65-17bdf3ff595e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41ea0e9f-80c5-4b4f-93eb-329aa71b016a");

            migrationBuilder.DropColumn(
                name: "DetailImg",
                table: "Smart_Solutions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "37d9f154-fa4e-41f3-b40a-2b8abdd25138", "6dc93b89-3f54-4894-addf-fd148cbd02cd", "Admin", "Admin", "Admin", new DateTime(2023, 7, 26, 2, 17, 35, 266, DateTimeKind.Utc).AddTicks(6821), new DateTime(2023, 7, 26, 2, 17, 35, 266, DateTimeKind.Utc).AddTicks(6826) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "3208a247-8509-4873-8f60-a4818596d4e2", 0, null, null, "62fccbc0-0499-4d68-b879-5b3acf9142b7", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEDlnfYLWPwAdes1WZ5UQbjzydfJf6dBxi+oDni45R3P90+R/Jj6ERlt7W/dNeryMJA==", null, false, null, null, "fabcfba2-a2ff-4653-8e0e-631430f51b96", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "37d9f154-fa4e-41f3-b40a-2b8abdd25138", "3208a247-8509-4873-8f60-a4818596d4e2" });
        }
    }
}
