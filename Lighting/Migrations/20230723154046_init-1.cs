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
                keyValues: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "55565517-bb27-4454-aad0-a19560359c82" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61bc216a-9943-4c54-b51d-0c0e6ad8a19f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55565517-bb27-4454-aad0-a19560359c82");

            migrationBuilder.CreateTable(
                name: "ProjectRef_Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRef_Products", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectRef_Products");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "474bb950-2acc-4ada-9f3f-d79cacb47dac", "Admin", "Admin", "Admin", new DateTime(2023, 7, 22, 14, 57, 22, 993, DateTimeKind.Utc).AddTicks(613), new DateTime(2023, 7, 22, 14, 57, 22, 993, DateTimeKind.Utc).AddTicks(616) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "55565517-bb27-4454-aad0-a19560359c82", 0, null, null, "7bce3fa4-aa11-474a-940b-ab66d70de8c2", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEG+FY/9MWWdVPRxBWaQAd3W16Yeohf/tpjgdoYhlhRkl4RYfZ6coG0l094T5EkXo9A==", null, false, null, null, "93e5714d-a2bf-4db7-beb1-26ee6d8e9a28", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "61bc216a-9943-4c54-b51d-0c0e6ad8a19f", "55565517-bb27-4454-aad0-a19560359c82" });
        }
    }
}
