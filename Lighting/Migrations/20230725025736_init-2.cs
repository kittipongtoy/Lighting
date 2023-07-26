using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "940673e6-9977-435e-b197-db0db1b2f704", "cc08dc2b-d700-4ddc-a9dd-4d4f334b5a66" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "940673e6-9977-435e-b197-db0db1b2f704");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc08dc2b-d700-4ddc-a9dd-4d4f334b5a66");

            migrationBuilder.AlterColumn<string>(
                name: "Location_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location_EN",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Folder_Path",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "File_Download",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content_EN",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Smart_Solution_Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName_TH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewImg = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solution_Categorys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "ea9a354f-292f-4794-b997-daf4c7a34825", "dab41ac9-4c9a-4add-9ca4-32a452c866fe", "Admin", "Admin", "Admin", new DateTime(2023, 7, 25, 2, 57, 35, 766, DateTimeKind.Utc).AddTicks(4584), new DateTime(2023, 7, 25, 2, 57, 35, 766, DateTimeKind.Utc).AddTicks(4588) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "9d50d803-7c2d-4840-9e3e-98607dce9f63", 0, null, null, "5b20c5f9-3bb8-4cc8-9dc7-e327dbabd5eb", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEM9LUlECWkIeI7B7uSK74hXsfHgzyUVB0HCXTvUudjqpxgShc1/2cyU/hHQ6nfJ4lw==", null, false, null, null, "3a47cf45-3e11-4b2f-b7c2-946c49a15bee", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ea9a354f-292f-4794-b997-daf4c7a34825", "9d50d803-7c2d-4840-9e3e-98607dce9f63" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smart_Solution_Categorys");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ea9a354f-292f-4794-b997-daf4c7a34825", "9d50d803-7c2d-4840-9e3e-98607dce9f63" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea9a354f-292f-4794-b997-daf4c7a34825");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d50d803-7c2d-4840-9e3e-98607dce9f63");

            migrationBuilder.AlterColumn<string>(
                name: "Location_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location_EN",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Folder_Path",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "File_Download",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content_TH",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content_EN",
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
                values: new object[] { "940673e6-9977-435e-b197-db0db1b2f704", "545e7e8b-2877-4967-9e28-89fb3519a543", "Admin", "Admin", "Admin", new DateTime(2023, 7, 23, 15, 40, 46, 114, DateTimeKind.Utc).AddTicks(9474), new DateTime(2023, 7, 23, 15, 40, 46, 114, DateTimeKind.Utc).AddTicks(9481) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "cc08dc2b-d700-4ddc-a9dd-4d4f334b5a66", 0, null, null, "c0ed654d-ff7a-4702-9b69-09398c96e290", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEBfml8jlHOKo5N+LvOlfM2NCR0iZ72ZTaYfHBdpEYGerVi6IRSue9Aq6HvAhJO1WZw==", null, false, null, null, "0091a4b8-6bf2-42cb-b9f7-570f880d59dc", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "940673e6-9977-435e-b197-db0db1b2f704", "cc08dc2b-d700-4ddc-a9dd-4d4f334b5a66" });
        }
    }
}
