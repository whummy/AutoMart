using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class imageupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee73ed01-7d9d-4887-a5de-41e251f45595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8641f2-826f-4d89-82d9-147ea909ef93");

            migrationBuilder.CreateTable(
                name: "ImageUploads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    imagepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploads", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44ef1f23-1736-4fb6-ad95-3c91aa134769", "cea56c0b-ac10-499f-874e-a62fdb7ccbdb", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e28332df-0141-43e3-b4f0-cd52181ffaa5", "6dfcd6b8-3308-4bdc-ae64-3add34b13d40", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUploads");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44ef1f23-1736-4fb6-ad95-3c91aa134769");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e28332df-0141-43e3-b4f0-cd52181ffaa5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee73ed01-7d9d-4887-a5de-41e251f45595", "7f9e01e3-0b19-4b6a-af9d-fab807fd24c8", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb8641f2-826f-4d89-82d9-147ea909ef93", "d3501357-c93d-4f69-ac1c-51bf602803b3", "Administrator", "ADMINISTRATOR" });
        }
    }
}
