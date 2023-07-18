using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class deletecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "3253be69-9712-4721-929e-52f8054dd7a2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b644be2-8504-4d59-8ebc-034ce6a63a99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3253be69-9712-4721-929e-52f8054dd7a2");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProjectRefs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "d3f2df07-b9ba-4314-8edd-08b54061183a", "540e0fea-0cbd-4025-812a-97c134e08d46", "Admin", "Admin", "Admin", new DateTime(2023, 7, 16, 4, 51, 35, 150, DateTimeKind.Utc).AddTicks(9027), new DateTime(2023, 7, 16, 4, 51, 35, 150, DateTimeKind.Utc).AddTicks(9032) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "f0768a2b-96f8-4138-97c6-e7bc0d9b1471", 0, null, null, "ff3b924f-be98-418a-b5ec-ca0daa622361", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEEWMKICOEhbsAPx+1ZFmqMQakN1PTAr9cONrUKzy2SewCjM9MX1gjsxFL2l518S1FQ==", null, false, null, null, "ff406ccc-418d-4ae5-b4d5-f6d4cbc412af", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d3f2df07-b9ba-4314-8edd-08b54061183a", "f0768a2b-96f8-4138-97c6-e7bc0d9b1471" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d3f2df07-b9ba-4314-8edd-08b54061183a", "f0768a2b-96f8-4138-97c6-e7bc0d9b1471" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3f2df07-b9ba-4314-8edd-08b54061183a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0768a2b-96f8-4138-97c6-e7bc0d9b1471");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProjectRefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "9b4b6049-32d6-4efc-a427-d74490a57153", "Admin", "Admin", "Admin", new DateTime(2023, 7, 16, 3, 43, 43, 523, DateTimeKind.Utc).AddTicks(8238), new DateTime(2023, 7, 16, 3, 43, 43, 523, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "3253be69-9712-4721-929e-52f8054dd7a2", 0, null, null, "4f1c68e2-2033-49a0-bb4e-b92e926fda0b", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEM6EDgTopkTG5SDTqsE0PyaPWoMB0D7cHAaqylIK+J+0GHnffgItsBt+/XEs3DvDJg==", null, false, null, null, "1c17c18c-d1fc-4703-855c-8301cc265a76", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "3253be69-9712-4721-929e-52f8054dd7a2" });
        }
    }
}
