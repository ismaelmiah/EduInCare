using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateRelationshipWithExamRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamRules_CourseId",
                table: "ExamRules");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_GradeId",
                table: "ExamRules");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_SubjectId",
                table: "ExamRules");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_CourseId",
                table: "ExamRules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_GradeId",
                table: "ExamRules",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_SubjectId",
                table: "ExamRules",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExamRules_CourseId",
                table: "ExamRules");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_GradeId",
                table: "ExamRules");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_SubjectId",
                table: "ExamRules");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_CourseId",
                table: "ExamRules",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_GradeId",
                table: "ExamRules",
                column: "GradeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_SubjectId",
                table: "ExamRules",
                column: "SubjectId",
                unique: true);
        }
    }
}
