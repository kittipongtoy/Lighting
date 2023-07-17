using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class addcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRefs_ProjectRef_Category_ProjectRef_CategoryId",
                table: "ProjectRefs");

            migrationBuilder.DropTable(
                name: "ProjectRef_Category");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "c2f461d5-d9b0-4898-ad1a-0410d4811d45" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3a15d21-654b-44f3-b128-100a61111c6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2f461d5-d9b0-4898-ad1a-0410d4811d45");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "644bd5f9-e0cc-463d-8f03-4b4943c48648", "18e23fd7-0e2a-469e-aeb6-ad6e35527310", "Admin", "Admin", "Admin", new DateTime(2023, 7, 14, 11, 18, 19, 79, DateTimeKind.Utc).AddTicks(7520), new DateTime(2023, 7, 14, 11, 18, 19, 79, DateTimeKind.Utc).AddTicks(7523) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "990fd8c4-6ae3-48a8-841a-90b38342cab4", 0, null, null, "b58bf374-cb07-462e-8e39-94d9d5f4a76a", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEAjx+S7a2STYiMa9HJlEvO2DOVJISjae3wf7LUodhJTG5LawvATBk0WJCmRuXF/Ybw==", null, false, null, null, "929c5f14-7cf3-41cb-89fb-681e92bbbaed", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "644bd5f9-e0cc-463d-8f03-4b4943c48648", "990fd8c4-6ae3-48a8-841a-90b38342cab4" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs",
                column: "ProjectRef_CategoryId",
                principalTable: "Category_Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "644bd5f9-e0cc-463d-8f03-4b4943c48648", "990fd8c4-6ae3-48a8-841a-90b38342cab4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "644bd5f9-e0cc-463d-8f03-4b4943c48648");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "990fd8c4-6ae3-48a8-841a-90b38342cab4");

            migrationBuilder.CreateTable(
                name: "ProjectRef_Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_EN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_TH = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRef_Category", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "574ec2c6-edbf-4b56-a591-32dbbe6ecb1b", "Admin", "Admin", "Admin", new DateTime(2023, 7, 14, 10, 43, 38, 903, DateTimeKind.Utc).AddTicks(4333), new DateTime(2023, 7, 14, 10, 43, 38, 903, DateTimeKind.Utc).AddTicks(4337) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "c2f461d5-d9b0-4898-ad1a-0410d4811d45", 0, null, null, "3227bbcf-e7dc-4f25-9231-bee98d8b134a", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEN3r1EWBuQ8Mi5hOjZWBvXvby1Iv3n8OqkSur72Odm6YSyrn8whHM7uyxhErC/vE9A==", null, false, null, null, "842dbce0-b605-4713-be64-74df1501ed1b", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b3a15d21-654b-44f3-b128-100a61111c6a", "c2f461d5-d9b0-4898-ad1a-0410d4811d45" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRefs_ProjectRef_Category_ProjectRef_CategoryId",
                table: "ProjectRefs",
                column: "ProjectRef_CategoryId",
                principalTable: "ProjectRef_Category",
                principalColumn: "Id");
        }
    }
}
