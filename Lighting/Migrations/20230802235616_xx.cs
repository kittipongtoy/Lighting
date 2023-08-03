using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e843a51d-69aa-43f7-af3c-a1af42a6982d", "dc6e496b-eafc-4f78-af5b-469c28f07e8c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e843a51d-69aa-43f7-af3c-a1af42a6982d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc6e496b-eafc-4f78-af5b-469c28f07e8c");

            migrationBuilder.CreateTable(
                name: "IR_Hightlight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_Hightlight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IR_HightlightDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetType = table.Column<int>(type: "int", nullable: false),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_TH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle_EN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IR_HightlightDetail", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "8e652c17-6cc1-43ba-823e-09d84a8e885f", "1aeca7a1-987e-48c5-aecc-27d7a06c4199", "Admin", "Admin", "Admin", new DateTime(2023, 8, 2, 23, 56, 15, 125, DateTimeKind.Utc).AddTicks(2730), new DateTime(2023, 8, 2, 23, 56, 15, 125, DateTimeKind.Utc).AddTicks(2734) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "71b59b32-20be-423e-ac4c-330168d9d331", 0, null, null, "cd9eb3ab-ca42-4c25-990b-2f9fca068bf2", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEICSUkiD0v8n38Lq/8P86CugQhsbwGUVPgtzOwto0rn5WwjDO8PQOmpCoamcGshs8g==", null, false, null, null, "bc7be392-d93f-4421-9a27-90ad5511d1d0", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e652c17-6cc1-43ba-823e-09d84a8e885f", "71b59b32-20be-423e-ac4c-330168d9d331" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IR_Hightlight");

            migrationBuilder.DropTable(
                name: "IR_HightlightDetail");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e652c17-6cc1-43ba-823e-09d84a8e885f", "71b59b32-20be-423e-ac4c-330168d9d331" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e652c17-6cc1-43ba-823e-09d84a8e885f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71b59b32-20be-423e-ac4c-330168d9d331");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "e843a51d-69aa-43f7-af3c-a1af42a6982d", "fb018693-48d5-4fdb-bde0-1d9bfc181aa1", "Admin", "Admin", "Admin", new DateTime(2023, 8, 2, 3, 7, 53, 90, DateTimeKind.Utc).AddTicks(2230), new DateTime(2023, 8, 2, 3, 7, 53, 90, DateTimeKind.Utc).AddTicks(2234) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "dc6e496b-eafc-4f78-af5b-469c28f07e8c", 0, null, null, "3565a7e0-e902-4555-a7f1-96201f951fac", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEHEZ8nUx2KQ2JdpKdKnHwWZsIbb/CmsFU4kzzn7kwvUi4BL60sxnMoTuEVwW5KM3gg==", null, false, null, null, "2abdc7d3-7b8c-4eac-931c-cf03760a206b", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e843a51d-69aa-43f7-af3c-a1af42a6982d", "dc6e496b-eafc-4f78-af5b-469c28f07e8c" });
        }
    }
}
