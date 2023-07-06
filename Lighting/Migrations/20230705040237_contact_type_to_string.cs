using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class contact_type_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b5af9919-197b-449f-8e2d-a15452b12d37", "4b8fd899-c9e8-4234-a936-2d06d191818d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5af9919-197b-449f-8e2d-a15452b12d37");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b8fd899-c9e8-4234-a936-2d06d191818d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "f0a0ca72-3d19-4f58-8af2-ffd99b8e3595", "63814619-c2ef-4aa2-80cb-d4833b2a6aeb", "Admin", "Admin", "Admin", new DateTime(2023, 7, 5, 4, 2, 37, 160, DateTimeKind.Utc).AddTicks(4126), new DateTime(2023, 7, 5, 4, 2, 37, 160, DateTimeKind.Utc).AddTicks(4129) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "fd3629df-4fe4-4480-b6a5-ab25268dfbe4", 0, null, null, "67e4d172-d2e7-48ad-8d43-1fde2182e652", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEFTXE1SxZNNAZxXhRGh+4eudokEa/U3IKO0kuY7uowRZROoRw425eeyn9jRDBYQqig==", null, false, null, null, "3e6e89fb-b618-4af1-b92e-ac5c778bd872", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f0a0ca72-3d19-4f58-8af2-ffd99b8e3595", "fd3629df-4fe4-4480-b6a5-ab25268dfbe4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f0a0ca72-3d19-4f58-8af2-ffd99b8e3595", "fd3629df-4fe4-4480-b6a5-ab25268dfbe4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0a0ca72-3d19-4f58-8af2-ffd99b8e3595");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd3629df-4fe4-4480-b6a5-ab25268dfbe4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "b5af9919-197b-449f-8e2d-a15452b12d37", "7a3e4198-dd0e-4417-8ae2-bcb973580ef6", "Admin", "Admin", "Admin", new DateTime(2023, 7, 5, 3, 56, 33, 129, DateTimeKind.Utc).AddTicks(2254), new DateTime(2023, 7, 5, 3, 56, 33, 129, DateTimeKind.Utc).AddTicks(2258) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "4b8fd899-c9e8-4234-a936-2d06d191818d", 0, null, null, "4137b9f5-a0d6-4885-86f3-094f94efa678", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELCUEqdBAvyyBFcrwGy1x3po3xT7hFSCUBOplAknP8JtZGOWYJXHznq8+DMbMa8bOQ==", null, false, null, null, "34229f3b-8bc5-4490-a988-e65f9b2a77f5", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b5af9919-197b-449f-8e2d-a15452b12d37", "4b8fd899-c9e8-4234-a936-2d06d191818d" });
        }
    }
}
