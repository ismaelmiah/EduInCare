using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class HeadertableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heading",
                table: "Headers");

            migrationBuilder.AddColumn<bool>(
                name: "ShowBannerImage",
                table: "Headers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowBannerImage",
                table: "Headers");

            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
