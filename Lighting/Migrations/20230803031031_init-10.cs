using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "aa781699-706d-43de-86a5-6b54f55c907b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa781699-706d-43de-86a5-6b54f55c907b");

            migrationBuilder.CreateTable(
                name: "MainContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEMail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEMail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleMapLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_File = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainContacts", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainContacts");

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
                values: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "daa64127-4c15-4c30-a72f-237b4164a15d", "Admin", "Admin", "Admin", new DateTime(2023, 8, 2, 8, 43, 49, 963, DateTimeKind.Utc).AddTicks(6704), new DateTime(2023, 8, 2, 8, 43, 49, 963, DateTimeKind.Utc).AddTicks(6707) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "aa781699-706d-43de-86a5-6b54f55c907b", 0, null, null, "4f73aa4d-8121-4565-a35c-29aef92083e3", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEHuyRJcfkrmpSJnAENR/iOVuF7q7vZNQafhwysCZMVquTbopyQH2PXVDY6XRABZIEw==", null, false, null, null, "1bc35976-2c65-499a-88a1-7809d4f88d09", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "aa781699-706d-43de-86a5-6b54f55c907b" });
        }
    }
}
