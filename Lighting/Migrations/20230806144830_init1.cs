using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2f4112f-5575-47bf-aa2b-8ff76f4be5d8", "3e9d701d-e276-4284-bdf4-a0380b962c9e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2f4112f-5575-47bf-aa2b-8ff76f4be5d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3e9d701d-e276-4284-bdf4-a0380b962c9e");

            migrationBuilder.AlterColumn<string>(
                name: "Title_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title_EN",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "L_AND_BIM_Link",
                table: "Downloads",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "bd58d2ba-5800-4c5f-abbf-57b20cb2b627", "Admin", "Admin", "Admin", new DateTime(2023, 8, 6, 14, 48, 29, 996, DateTimeKind.Utc).AddTicks(891), new DateTime(2023, 8, 6, 14, 48, 29, 996, DateTimeKind.Utc).AddTicks(894) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "d7e182e9-b59d-48bb-80c4-b048b7593e6a", 0, null, null, "606c05e6-aa5c-4f59-93bc-826e2793d73d", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAELC0rcDuW0PK5PENYOgkXI75JCEOUzD+4xZfqBpSgg0AYnCiHvFc4s6rLOCb4ccnwg==", null, false, null, null, "46694da2-4a43-4f69-a223-a2d6162b86a7", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "d7e182e9-b59d-48bb-80c4-b048b7593e6a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea1efcf8-35d2-48c4-8a60-cd415ccc7490", "d7e182e9-b59d-48bb-80c4-b048b7593e6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1efcf8-35d2-48c4-8a60-cd415ccc7490");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7e182e9-b59d-48bb-80c4-b048b7593e6a");

            migrationBuilder.DropColumn(
                name: "L_AND_BIM_Link",
                table: "Downloads");

            migrationBuilder.AlterColumn<string>(
                name: "Title_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title_EN",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "d2f4112f-5575-47bf-aa2b-8ff76f4be5d8", "54d675c4-e707-4e46-b259-503f8692eb91", "Admin", "Admin", "Admin", new DateTime(2023, 8, 6, 10, 2, 53, 746, DateTimeKind.Utc).AddTicks(8632), new DateTime(2023, 8, 6, 10, 2, 53, 746, DateTimeKind.Utc).AddTicks(8637) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "3e9d701d-e276-4284-bdf4-a0380b962c9e", 0, null, null, "f686a5c9-b9f2-4c69-b825-0b7f199a829f", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEKptn4PcAFfU7q/hO6Q/9qj4JKMxGe+qOx2n08E1qDZnuRcUQDG7hqc52swF7gTTrg==", null, false, null, null, "a1ab945b-6cb4-46f4-bc0e-938d1ab8be02", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d2f4112f-5575-47bf-aa2b-8ff76f4be5d8", "3e9d701d-e276-4284-bdf4-a0380b962c9e" });
        }
    }
}
