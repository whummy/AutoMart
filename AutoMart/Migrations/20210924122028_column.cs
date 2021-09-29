using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb5cecce-359d-462f-bea8-e07a2262999e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e006e4af-5ae5-43ca-b13f-16a7c952e0f1");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cars",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea2b27a1-0981-4eea-b477-c5898a15758d", "19dbbf11-735e-4c1d-be7b-2bd3dd04dd92", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb2df1fa-1099-4d89-b573-3a4e93080d67", "258d2b48-72c6-41ec-906f-db937dbee46e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb2df1fa-1099-4d89-b573-3a4e93080d67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea2b27a1-0981-4eea-b477-c5898a15758d");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "CarId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e006e4af-5ae5-43ca-b13f-16a7c952e0f1", "142befa7-e057-4c6e-ad3a-3610cc5be355", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb5cecce-359d-462f-bea8-e07a2262999e", "7a7cbdc2-42d2-4c23-9b92-5a0197b48a62", "Administrator", "ADMINISTRATOR" });
        }
    }
}
