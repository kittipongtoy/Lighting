using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class addcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMaps_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YouTube_Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "69b3891d-1e86-4f2a-84c8-7b7d8fccc254", "3ca87561-e607-45b3-85a7-449d2f748113", "Admin", "Admin", "Admin", new DateTime(2023, 7, 5, 4, 7, 32, 718, DateTimeKind.Utc).AddTicks(5628), new DateTime(2023, 7, 5, 4, 7, 32, 718, DateTimeKind.Utc).AddTicks(5632) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "306b2232-df9b-406d-b2e9-7aa7af541fa4", 0, null, null, "a2833200-24c1-43c7-979e-e246440e2421", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEID6V7aOmYhJ5DL8muBhRb4GIkuQJ5znnsyFOO58tuTUh4U0M61T6+Tv0YdOgVRJJA==", null, false, null, null, "fed24152-0e34-4e23-9a68-cf1df871a013", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "69b3891d-1e86-4f2a-84c8-7b7d8fccc254", "306b2232-df9b-406d-b2e9-7aa7af541fa4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "69b3891d-1e86-4f2a-84c8-7b7d8fccc254", "306b2232-df9b-406d-b2e9-7aa7af541fa4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b3891d-1e86-4f2a-84c8-7b7d8fccc254");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "306b2232-df9b-406d-b2e9-7aa7af541fa4");

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
    }
}
