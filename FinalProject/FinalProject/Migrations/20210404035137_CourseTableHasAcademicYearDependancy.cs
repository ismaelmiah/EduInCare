using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class CourseTableHasAcademicYearDependancy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AcademicYearId",
                table: "Courses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses",
                column: "AcademicYearId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AcademicYears_AcademicYearId",
                table: "Courses",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AcademicYears_AcademicYearId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AcademicYearId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AcademicYearId",
                table: "Courses");
        }
    }
}
