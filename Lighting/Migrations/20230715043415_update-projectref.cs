using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class updateprojectref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProjectRefs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "4c220f57-ddd8-4438-ab44-f0e4a62c1b52", "83ea3274-9c59-4c34-b851-3a5aae53dad1", "Admin", "Admin", "Admin", new DateTime(2023, 7, 15, 4, 34, 14, 850, DateTimeKind.Utc).AddTicks(8169), new DateTime(2023, 7, 15, 4, 34, 14, 850, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "0f10dca6-6176-4ca7-828e-5bcb03d5e817", 0, null, null, "557210bc-5c79-4ffb-ad05-23c4de7eebb4", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEPRyWcD0jJ13jnXWob88vWYd5pJFG9+oSQiXsI5YxgTsursbfWBj/TSl/LZKh43OyQ==", null, false, null, null, "f04595ca-76bd-48d3-b40e-d93f78106380", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c220f57-ddd8-4438-ab44-f0e4a62c1b52", "0f10dca6-6176-4ca7-828e-5bcb03d5e817" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c220f57-ddd8-4438-ab44-f0e4a62c1b52", "0f10dca6-6176-4ca7-828e-5bcb03d5e817" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c220f57-ddd8-4438-ab44-f0e4a62c1b52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f10dca6-6176-4ca7-828e-5bcb03d5e817");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProjectRefs");

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
        }
    }
}
