using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class droptablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cca7fbbc-2586-4e65-b5af-44308dd30362", "9e359795-fd1d-44be-af4a-e9b4a3936c89" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cca7fbbc-2586-4e65-b5af-44308dd30362");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e359795-fd1d-44be-af4a-e9b4a3936c89");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_EN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "6ddab358-a89c-43ec-9886-42fa8bb16b7e", "31c5f576-31b7-4fba-b925-755967a925d1", "Admin", "Admin", "Admin", new DateTime(2023, 6, 30, 4, 29, 39, 246, DateTimeKind.Utc).AddTicks(1686), new DateTime(2023, 6, 30, 4, 29, 39, 246, DateTimeKind.Utc).AddTicks(1689) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "acb317a2-6b51-4dfd-97cf-146a88fd05d0", 0, null, null, "3b30b1b4-d91d-418d-b7c6-2f486f7dd46d", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELGbDPN0z3sJGHm7NaDHwrWMTsySV/9TqI6xWI/nmwW7iFLJTF2kpaVIR4ZembC9+g==", null, false, null, null, "6b14c76a-08ed-43c1-b307-00cde9d0af97", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ddab358-a89c-43ec-9886-42fa8bb16b7e", "acb317a2-6b51-4dfd-97cf-146a88fd05d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ddab358-a89c-43ec-9886-42fa8bb16b7e", "acb317a2-6b51-4dfd-97cf-146a88fd05d0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ddab358-a89c-43ec-9886-42fa8bb16b7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acb317a2-6b51-4dfd-97cf-146a88fd05d0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "cca7fbbc-2586-4e65-b5af-44308dd30362", "75f47ce2-dd66-43c0-82dc-88ebbfe4d293", "Admin", "Admin", "Admin", new DateTime(2023, 6, 29, 5, 42, 44, 141, DateTimeKind.Utc).AddTicks(5929), new DateTime(2023, 6, 29, 5, 42, 44, 141, DateTimeKind.Utc).AddTicks(5931) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "9e359795-fd1d-44be-af4a-e9b4a3936c89", 0, null, null, "cf480a6d-052b-47b6-b2cf-1282645cdd2f", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELi7ZvYMUp+IIaaTR9F/ELvhHM1VeTQjIsTLc1VLKTUEj43uswDO4Cse3f/qOaY2bA==", null, false, null, null, "5ef959cd-238c-41fc-a956-4391bc114ebd", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cca7fbbc-2586-4e65-b5af-44308dd30362", "9e359795-fd1d-44be-af4a-e9b4a3936c89" });
        }
    }
}
