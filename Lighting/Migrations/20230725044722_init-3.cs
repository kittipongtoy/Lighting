using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Smart_Solutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleName_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreviewImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title1_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title2_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content1_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content1_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content2_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content2_EN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solutions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Smart_Solution_Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Smart_SolutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smart_Solution_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smart_Solution_Links_Smart_Solutions_Smart_SolutionId",
                        column: x => x.Smart_SolutionId,
                        principalTable: "Smart_Solutions",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Smart_Solution_Links_Smart_SolutionId",
                table: "Smart_Solution_Links",
                column: "Smart_SolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Smart_Solution_Links");

            migrationBuilder.DropTable(
                name: "Smart_Solutions");

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
    }
}
