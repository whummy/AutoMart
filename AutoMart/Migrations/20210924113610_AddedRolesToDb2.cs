using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class AddedRolesToDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae64106-80a7-445f-96c5-1e62037ce521");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd452c6c-3a6a-4030-90bc-6a083cdf5ab2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e006e4af-5ae5-43ca-b13f-16a7c952e0f1", "142befa7-e057-4c6e-ad3a-3610cc5be355", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb5cecce-359d-462f-bea8-e07a2262999e", "7a7cbdc2-42d2-4c23-9b92-5a0197b48a62", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb5cecce-359d-462f-bea8-e07a2262999e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e006e4af-5ae5-43ca-b13f-16a7c952e0f1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd452c6c-3a6a-4030-90bc-6a083cdf5ab2", "902fce0e-d2c0-4c9c-9802-ed332e219835", "SuperUser", "SUPERUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ae64106-80a7-445f-96c5-1e62037ce521", "a940e471-3b16-47d3-a7e6-fe4669e5ed08", "Administrator", "ADMINISTRATOR" });
        }
    }
}
