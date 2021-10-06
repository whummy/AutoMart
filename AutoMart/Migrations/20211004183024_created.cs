using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "175cc0de-acbd-43b9-8f59-0d87a3681693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "868f8f7a-f559-46ac-aaa2-f7fa854dba13");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee73ed01-7d9d-4887-a5de-41e251f45595", "7f9e01e3-0b19-4b6a-af9d-fab807fd24c8", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb8641f2-826f-4d89-82d9-147ea909ef93", "d3501357-c93d-4f69-ac1c-51bf602803b3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee73ed01-7d9d-4887-a5de-41e251f45595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8641f2-826f-4d89-82d9-147ea909ef93");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "868f8f7a-f559-46ac-aaa2-f7fa854dba13", "ffc5498f-5d54-4323-888f-12c6663765d1", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "175cc0de-acbd-43b9-8f59-0d87a3681693", "30a10d80-139a-41ae-a3b5-addff96a8f6a", "Administrator", "ADMINISTRATOR" });
        }
    }
}
