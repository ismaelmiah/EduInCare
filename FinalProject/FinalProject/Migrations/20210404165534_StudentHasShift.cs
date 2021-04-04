using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class StudentHasShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Students");
        }
    }
}
