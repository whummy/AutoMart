using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb2df1fa-1099-4d89-b573-3a4e93080d67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea2b27a1-0981-4eea-b477-c5898a15758d");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0181525-6a91-4587-acff-9dfcb3d5ffee", "f09797b3-d166-4f78-b3e7-aef42c3304aa", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0a6a7db-1d19-4a4d-8061-083e009a9953", "2bed4011-0274-41ce-8471-6e764ad937db", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0a6a7db-1d19-4a4d-8061-083e009a9953");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0181525-6a91-4587-acff-9dfcb3d5ffee");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea2b27a1-0981-4eea-b477-c5898a15758d", "19dbbf11-735e-4c1d-be7b-2bd3dd04dd92", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb2df1fa-1099-4d89-b573-3a4e93080d67", "258d2b48-72c6-41ec-906f-db937dbee46e", "Administrator", "ADMINISTRATOR" });
        }
    }
}
