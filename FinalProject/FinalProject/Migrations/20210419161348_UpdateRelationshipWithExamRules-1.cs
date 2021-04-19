using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateRelationshipWithExamRules1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
