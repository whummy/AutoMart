using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoMart.Migrations
{
    public partial class BrandnullibleUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_UserId",
                table: "Brands");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserId",
                table: "Brands",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_UserId",
                table: "Brands");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Brands",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_UserId",
                table: "Brands",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_UserId",
                table: "Brands",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
