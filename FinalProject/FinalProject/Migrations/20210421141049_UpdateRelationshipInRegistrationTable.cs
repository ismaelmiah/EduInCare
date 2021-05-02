using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateRelationshipInRegistrationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AcademicYears_AcademicYearId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Courses_CourseId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AcademicYearId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_CourseId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_SectionId",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AcademicYearId",
                table: "Registrations",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CourseId",
                table: "Registrations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SectionId",
                table: "Registrations",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ExamId",
                table: "Marks",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Exams_ExamId",
                table: "Marks",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AcademicYears_AcademicYearId",
                table: "Registrations",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Courses_CourseId",
                table: "Registrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                table: "Registrations",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Exams_ExamId",
                table: "Marks");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_AcademicYears_AcademicYearId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Courses_CourseId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AcademicYearId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_CourseId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_SectionId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Marks_ExamId",
                table: "Marks");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AcademicYearId",
                table: "Registrations",
                column: "AcademicYearId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CourseId",
                table: "Registrations",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_SectionId",
                table: "Registrations",
                column: "SectionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_AcademicYears_AcademicYearId",
                table: "Registrations",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Courses_CourseId",
                table: "Registrations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Sections_SectionId",
                table: "Registrations",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
