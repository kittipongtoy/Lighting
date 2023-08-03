using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4358ef7-7af7-41c0-9982-d56a1923477d", "2385ad47-682b-4231-84f8-29af296470d8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4358ef7-7af7-41c0-9982-d56a1923477d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2385ad47-682b-4231-84f8-29af296470d8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "8972a141-4422-4e47-9fe1-f2f532a1f94e", "bbb340a3-dda7-44ac-b55f-738c69bcf088", "Admin", "Admin", "Admin", new DateTime(2023, 8, 3, 11, 20, 14, 152, DateTimeKind.Utc).AddTicks(9760), new DateTime(2023, 8, 3, 11, 20, 14, 152, DateTimeKind.Utc).AddTicks(9764) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "126ed3f4-54ad-4c86-a791-d7313f488ba0", 0, null, null, "19c310a8-537a-4860-9436-ee913543fcde", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEGuM8n9chSfpqj6AFr2SL2G3NH8TrT+aqdCoLO83PAsS8LaSxESDbbbC2/BXoOtyXQ==", null, false, null, null, "1149b599-bb8b-469c-b6b4-4308ab0b029a", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8972a141-4422-4e47-9fe1-f2f532a1f94e", "126ed3f4-54ad-4c86-a791-d7313f488ba0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8972a141-4422-4e47-9fe1-f2f532a1f94e", "126ed3f4-54ad-4c86-a791-d7313f488ba0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8972a141-4422-4e47-9fe1-f2f532a1f94e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "126ed3f4-54ad-4c86-a791-d7313f488ba0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "f4358ef7-7af7-41c0-9982-d56a1923477d", "de9857bd-fff0-49f4-bea6-9e8afff06151", "Admin", "Admin", "Admin", new DateTime(2023, 8, 3, 3, 10, 30, 943, DateTimeKind.Utc).AddTicks(6311), new DateTime(2023, 8, 3, 3, 10, 30, 943, DateTimeKind.Utc).AddTicks(6316) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "2385ad47-682b-4231-84f8-29af296470d8", 0, null, null, "2fc350c7-c8f7-43fd-8d73-08d9a85a064f", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEEYsdFi6ewDbhgoaM/hkUkUIC09A+jhPCo6tUnwi5xh+NEIIURaYQ2ogdAS4MzioQA==", null, false, null, null, "44c25b0d-8b26-497f-9843-2bc9b426f862", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f4358ef7-7af7-41c0-9982-d56a1923477d", "2385ad47-682b-4231-84f8-29af296470d8" });
        }
    }
}
