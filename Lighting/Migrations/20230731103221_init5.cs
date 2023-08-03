using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35c7485c-1762-400f-b5f8-0de8321925ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "IR_Button_Below_Banner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "83b044bc-02aa-4c88-9101-369ce0bcf141", "3f01f0e6-26a5-4fc3-b960-0da2ecc5c74c", "Admin", "Admin", "Admin", new DateTime(2023, 7, 31, 10, 32, 21, 365, DateTimeKind.Utc).AddTicks(7612), new DateTime(2023, 7, 31, 10, 32, 21, 365, DateTimeKind.Utc).AddTicks(7615) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "954348f4-cda8-495e-923c-4a93fce6037a", 0, null, null, "7aea3b74-1b76-466a-94be-8127d3ab0a8c", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAECBymPSlhMufv1TIzxjeHLw6qWT9wxGK7c+qDa12roO2dw/iYr78s3AYsPqRdbCPZQ==", null, false, null, null, "3fd7032b-8229-4a96-8172-1d7cfb62ac34", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "83b044bc-02aa-4c88-9101-369ce0bcf141", "954348f4-cda8-495e-923c-4a93fce6037a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "83b044bc-02aa-4c88-9101-369ce0bcf141", "954348f4-cda8-495e-923c-4a93fce6037a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b044bc-02aa-4c88-9101-369ce0bcf141");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "954348f4-cda8-495e-923c-4a93fce6037a");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "IR_Button_Below_Banner");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "193d2181-cedf-4710-9179-1c3446f41e73", "Admin", "Admin", "Admin", new DateTime(2023, 7, 28, 14, 31, 45, 138, DateTimeKind.Utc).AddTicks(7021), new DateTime(2023, 7, 28, 14, 31, 45, 138, DateTimeKind.Utc).AddTicks(7024) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2", 0, null, null, "74acc846-380c-4b32-9f87-c759229433e2", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEJ+YxgQDskzlc6kpJivFR7MCk/FAsOnNd8D+JrU7K/zleZ4dLHbvJQVopsvS3cBzhQ==", null, false, null, null, "da006e1c-f1dd-4a2f-aa22-7897fcfff8ee", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35c7485c-1762-400f-b5f8-0de8321925ea", "641469a6-df8c-44d0-8b8a-1cdeb4f8abe2" });
        }
    }
}
