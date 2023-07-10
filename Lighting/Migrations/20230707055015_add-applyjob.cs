using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class addapplyjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ApplyJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlace_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respondsibility_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Respondsibility_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualification_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "2d49a22f-88f0-4e55-8672-dd6a85a8dc9a", "Admin", "Admin", "Admin", new DateTime(2023, 7, 7, 5, 50, 14, 778, DateTimeKind.Utc).AddTicks(4669), new DateTime(2023, 7, 7, 5, 50, 14, 778, DateTimeKind.Utc).AddTicks(4673) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "822888e5-bfe7-4ba5-a551-85b62b77d0b0", 0, null, null, "e9dba9a6-7701-4c21-8c0b-2f2a64175390", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEK5PEJl2pA5uLgneLXLtVN56JQgkG9pYhchVr7zQWbjy+OItylZEvJp0RzVQS4zCvQ==", null, false, null, null, "42f3019d-b51a-43e2-b000-c3e33116c554", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "822888e5-bfe7-4ba5-a551-85b62b77d0b0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobs");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd57ef74-02fa-4a0e-9720-c602eac28b4a", "822888e5-bfe7-4ba5-a551-85b62b77d0b0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd57ef74-02fa-4a0e-9720-c602eac28b4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "822888e5-bfe7-4ba5-a551-85b62b77d0b0");

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
    }
}
