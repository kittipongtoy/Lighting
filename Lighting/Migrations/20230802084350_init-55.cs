using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lighting.Migrations
{
    public partial class init55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "File_Download",
                table: "ProjectRefs");

            migrationBuilder.DropColumn(
                name: "Beam_Angle",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Control_Gear",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Equivalent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Finishing",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gasket",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Housing",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lamp_Colour",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Lens",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Luminaire_Lifetime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Luminaire_Output",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Mounting",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Power_Supply",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "Product_Spects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Spects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Spects_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NameThai", "NormalizedName", "created_at", "updated_at" },
                values: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "daa64127-4c15-4c30-a72f-237b4164a15d", "Admin", "Admin", "Admin", new DateTime(2023, 8, 2, 8, 43, 49, 963, DateTimeKind.Utc).AddTicks(6704), new DateTime(2023, 8, 2, 8, 43, 49, 963, DateTimeKind.Utc).AddTicks(6707) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ApplicationFile", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeCode", "EmployeeCodeInt", "Firstname", "GuarantorIdentificationCardFile", "Isactive", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePath", "ReceptionistFile", "SecurityStamp", "TwoFactorEnabled", "UserName", "created_at", "updated_at" },
                values: new object[] { "aa781699-706d-43de-86a5-6b54f55c907b", 0, null, null, "4f73aa4d-8121-4565-a35c-29aef92083e3", "Admin@Lighting.com", false, "Admin", 1, "Admin", null, null, "Admin", false, null, "", "admin@lighting.com", "AQAAAAEAACcQAAAAEHuyRJcfkrmpSJnAENR/iOVuF7q7vZNQafhwysCZMVquTbopyQH2PXVDY6XRABZIEw==", null, false, null, null, "1bc35976-2c65-499a-88a1-7809d4f88d09", false, "Admin@Lighting.com", null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "aa781699-706d-43de-86a5-6b54f55c907b" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_Spects_ProductId",
                table: "Product_Spects",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Spects");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48", "aa781699-706d-43de-86a5-6b54f55c907b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dc56d8e-e62d-46b7-9f86-9cd2a2396f48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa781699-706d-43de-86a5-6b54f55c907b");

            migrationBuilder.AddColumn<string>(
                name: "File_Download",
                table: "ProjectRefs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beam_Angle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Control_Gear",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equivalent",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Finishing",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gasket",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Housing",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lamp_Colour",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lens",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Luminaire_Lifetime",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Luminaire_Output",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mounting",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Power_Supply",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Products",
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
    }
}
