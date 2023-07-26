using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0cd379d5-5850-4463-a73f-ca6ac990a8a5", "118f2dd5-818e-4be2-9f62-c3b57f4e1f61" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cd379d5-5850-4463-a73f-ca6ac990a8a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "118f2dd5-818e-4be2-9f62-c3b57f4e1f61");

            migrationBuilder.DropColumn(
                name: "Content1_EN",
                table: "Smart_Solutions");

            migrationBuilder.DropColumn(
                name: "Content1_TH",
                table: "Smart_Solutions");

            migrationBuilder.DropColumn(
                name: "Content2_EN",
                table: "Smart_Solutions");

            migrationBuilder.DropColumn(
                name: "Content2_TH",
                table: "Smart_Solutions");

            migrationBuilder.DropColumn(
                name: "Title1_EN",
                table: "Smart_Solutions");

            migrationBuilder.DropColumn(
                name: "Title1_TH",
                table: "Smart_Solutions");

            migrationBuilder.RenameColumn(
                name: "Title2_TH",
                table: "Smart_Solutions",
                newName: "Content_TH");

            migrationBuilder.RenameColumn(
                name: "Title2_EN",
                table: "Smart_Solutions",
                newName: "Content_EN");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Content_TH",
                table: "Smart_Solutions",
                newName: "Title2_TH");

            migrationBuilder.RenameColumn(
                name: "Content_EN",
                table: "Smart_Solutions",
                newName: "Title2_EN");

            migrationBuilder.AddColumn<string>(
                name: "Content1_EN",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content1_TH",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content2_EN",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content2_TH",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title1_EN",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title1_TH",
                table: "Smart_Solutions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "0cd379d5-5850-4463-a73f-ca6ac990a8a5", "34913107-adde-43b0-b8b0-9a67a1d49c12", "Admin", "Admin", "Admin", new DateTime(2023, 7, 25, 4, 47, 21, 161, DateTimeKind.Utc).AddTicks(8555), new DateTime(2023, 7, 25, 4, 47, 21, 161, DateTimeKind.Utc).AddTicks(8574) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "118f2dd5-818e-4be2-9f62-c3b57f4e1f61", 0, null, null, "d5348fad-bcb5-44a5-99fe-63bdb5b1f3bc", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEA5j/uhurIgkdhXcnULPF9UN4FBtnkin4EQKnXpJTYIbtShk902AMWuBBdTJWb+zIQ==", null, false, null, null, "b44bdf04-11b7-48ab-88d6-2c6a734cf5e0", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0cd379d5-5850-4463-a73f-ca6ac990a8a5", "118f2dd5-818e-4be2-9f62-c3b57f4e1f61" });
        }
    }
}
