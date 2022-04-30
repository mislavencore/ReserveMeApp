using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddingItemCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CompanyId",
                table: "Items",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Companies_CompanyId",
                table: "Items",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Companies_CompanyId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CompanyId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Items");
        }
    }
}
