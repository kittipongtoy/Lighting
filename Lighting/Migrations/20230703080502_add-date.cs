using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class adddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "News",
                newName: "CreateDate_TH");

            migrationBuilder.AddColumn<string>(
                name: "CreateDate_EN",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreateDate_EN",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CreateDate_TH",
                table: "News",
                newName: "CreateDate");

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
    }
}
