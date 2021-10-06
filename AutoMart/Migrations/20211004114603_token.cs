using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class token : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fc8e0e8-06bb-4955-b346-faf5ff54edda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6413530c-08c0-4806-82f7-7dc17d235116");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "868f8f7a-f559-46ac-aaa2-f7fa854dba13", "ffc5498f-5d54-4323-888f-12c6663765d1", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "175cc0de-acbd-43b9-8f59-0d87a3681693", "30a10d80-139a-41ae-a3b5-addff96a8f6a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "175cc0de-acbd-43b9-8f59-0d87a3681693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "868f8f7a-f559-46ac-aaa2-f7fa854dba13");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Brands");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6413530c-08c0-4806-82f7-7dc17d235116", "9042b1a8-b9c4-4bca-8985-509972981350", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4fc8e0e8-06bb-4955-b346-faf5ff54edda", "296a71cd-ab87-48f4-a709-3a7f2fbd731a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
