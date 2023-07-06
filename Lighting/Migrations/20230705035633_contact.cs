using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "13d0b3ef-faeb-473f-9791-7a6c81ba6979", "b86a5c51-abdb-4b05-9ab2-735163ce3dd4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13d0b3ef-faeb-473f-9791-7a6c81ba6979");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b86a5c51-abdb-4b05-9ab2-735163ce3dd4");

            migrationBuilder.AlterColumn<string>(
                name: "Title_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreateDate_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreateDate_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Title_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateDate_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateDate_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content_TH",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "13d0b3ef-faeb-473f-9791-7a6c81ba6979", "171add69-ad56-43ed-80a2-c12cfff9d99b", "Admin", "Admin", "Admin", new DateTime(2023, 7, 3, 8, 5, 1, 537, DateTimeKind.Utc).AddTicks(6092), new DateTime(2023, 7, 3, 8, 5, 1, 537, DateTimeKind.Utc).AddTicks(6094) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "b86a5c51-abdb-4b05-9ab2-735163ce3dd4", 0, null, null, "896a03d4-ce30-4a71-86a9-3c8bf0f30d4d", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEFDGi2gYVy9rhe8jWN35QfWbiWrqt8iN41AiKWkPj9e2EdLL7Um5lOqOWIokomouxA==", null, false, null, null, "f9136f97-dc24-43e1-96e2-b3cc3402766e", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "13d0b3ef-faeb-473f-9791-7a6c81ba6979", "b86a5c51-abdb-4b05-9ab2-735163ce3dd4" });
        }
    }
}
