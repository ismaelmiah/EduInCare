using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class RecordMetaTableInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecordMetaId",
                table: "Applicants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RecordMeta",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedLast = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordMeta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_CourseId",
                table: "Applicants",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_RecordMetaId",
                table: "Applicants",
                column: "RecordMetaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Courses_CourseId",
                table: "Applicants",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_RecordMeta_RecordMetaId",
                table: "Applicants",
                column: "RecordMetaId",
                principalTable: "RecordMeta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Courses_CourseId",
                table: "Applicants");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_RecordMeta_RecordMetaId",
                table: "Applicants");

            migrationBuilder.DropTable(
                name: "RecordMeta");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_CourseId",
                table: "Applicants");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_RecordMetaId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "RecordMetaId",
                table: "Applicants");
        }
    }
}
