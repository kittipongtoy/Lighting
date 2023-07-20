using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class upadetprojectref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRef_CategoryId",
                table: "ProjectRefs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "9b4b6049-32d6-4efc-a427-d74490a57153", "Admin", "Admin", "Admin", new DateTime(2023, 7, 16, 3, 43, 43, 523, DateTimeKind.Utc).AddTicks(8238), new DateTime(2023, 7, 16, 3, 43, 43, 523, DateTimeKind.Utc).AddTicks(8241) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "3253be69-9712-4721-929e-52f8054dd7a2", 0, null, null, "4f1c68e2-2033-49a0-bb4e-b92e926fda0b", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEM6EDgTopkTG5SDTqsE0PyaPWoMB0D7cHAaqylIK+J+0GHnffgItsBt+/XEs3DvDJg==", null, false, null, null, "1c17c18c-d1fc-4703-855c-8301cc265a76", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "3253be69-9712-4721-929e-52f8054dd7a2" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs",
                column: "ProjectRef_CategoryId",
                principalTable: "Category_Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6b644be2-8504-4d59-8ebc-034ce6a63a99", "3253be69-9712-4721-929e-52f8054dd7a2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b644be2-8504-4d59-8ebc-034ce6a63a99");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3253be69-9712-4721-929e-52f8054dd7a2");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectRef_CategoryId",
                table: "ProjectRefs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRefs_Category_Projects_ProjectRef_CategoryId",
                table: "ProjectRefs",
                column: "ProjectRef_CategoryId",
                principalTable: "Category_Projects",
                principalColumn: "Id");
        }
    }
}
