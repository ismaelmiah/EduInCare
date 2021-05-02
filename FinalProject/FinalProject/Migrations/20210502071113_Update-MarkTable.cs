using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateMarkTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Exams_ExamId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_ExamId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_ExamId",
                table: "ExamRules");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Marks");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Marks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExamRulesId",
                table: "Marks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ExamRulesId",
                table: "Marks",
                column: "ExamRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_ExamId",
                table: "ExamRules",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_ExamRules_ExamRulesId",
                table: "Marks",
                column: "ExamRulesId",
                principalTable: "ExamRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules");

            migrationBuilder.DropForeignKey(
                name: "FK_Marks_ExamRules_ExamRulesId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_ExamRulesId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_ExamRules_ExamId",
                table: "ExamRules");

            migrationBuilder.DropColumn(
                name: "ExamRulesId",
                table: "Marks");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Marks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "Marks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_ExamId",
                table: "Marks",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Marks_SubjectId",
                table: "Marks",
                column: "SubjectId",
                unique: true,
                filter: "[SubjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ExamRules_ExamId",
                table: "ExamRules",
                column: "ExamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamRules_Exams_ExamId",
                table: "ExamRules",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Exams_ExamId",
                table: "Marks",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
