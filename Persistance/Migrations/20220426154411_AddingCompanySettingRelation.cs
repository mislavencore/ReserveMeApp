using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class AddingCompanySettingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Settings",
                newName: "SettingName");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CompanyId",
                table: "Settings",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Companies_CompanyId",
                table: "Settings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Companies_CompanyId",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_CompanyId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "SettingName",
                table: "Settings",
                newName: "Name");
        }
    }
}
