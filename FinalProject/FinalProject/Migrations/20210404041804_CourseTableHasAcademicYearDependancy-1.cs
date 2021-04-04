using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class CourseTableHasAcademicYearDependancy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses",
                column: "AcademicYearId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses",
                column: "AcademicYearId",
                unique: true);
        }
    }
}
