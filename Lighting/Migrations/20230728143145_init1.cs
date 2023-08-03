using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsImgContents");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c75627f-e05b-4ab4-98c3-377132401dd1", "10fb774f-7ed3-4dbb-b57e-0638aaedf16f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c75627f-e05b-4ab4-98c3-377132401dd1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10fb774f-7ed3-4dbb-b57e-0638aaedf16f");

            migrationBuilder.CreateTable(
                name: "ApplyJobImgContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefit_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefit_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplyJobImgContents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "193d2181-cedf-4710-9179-1c3446f41e73", "Admin", "Admin", "Admin", new DateTime(2023, 7, 28, 14, 31, 45, 138, DateTimeKind.Utc).AddTicks(7021), new DateTime(2023, 7, 28, 14, 31, 45, 138, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2", 0, null, null, "74acc846-380c-4b32-9f87-c759229433e2", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEJ+YxgQDskzlc6kpJivFR7MCk/FAsOnNd8D+JrU7K/zleZ4dLHbvJQVopsvS3cBzhQ==", null, false, null, null, "da006e1c-f1dd-4a2f-aa22-7897fcfff8ee", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplyJobImgContents");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35c7485c-1762-400f-b5f8-0de8321925ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2");

            migrationBuilder.CreateTable(
                name: "NewsImgContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Benefit_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benefit_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position_pdf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImgContents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "2c75627f-e05b-4ab4-98c3-377132401dd1", "8b9c68f1-a3a1-46c7-8d6a-bce61e32e0f2", "Admin", "Admin", "Admin", new DateTime(2023, 7, 28, 9, 8, 30, 148, DateTimeKind.Utc).AddTicks(6388), new DateTime(2023, 7, 28, 9, 8, 30, 148, DateTimeKind.Utc).AddTicks(6394) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "10fb774f-7ed3-4dbb-b57e-0638aaedf16f", 0, null, null, "856eef02-a0ae-498f-85fe-1b2f0f7e7ac0", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEBWngHh5ZOG1GixF9hki/Asi4J8Tg0BGQ98BE2o9UwW+nFwrIIOY5uaJDW1K5D7I9A==", null, false, null, null, "d355b9b6-8a42-4c62-80b4-58b85488136a", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c75627f-e05b-4ab4-98c3-377132401dd1", "10fb774f-7ed3-4dbb-b57e-0638aaedf16f" });
        }
    }
}
