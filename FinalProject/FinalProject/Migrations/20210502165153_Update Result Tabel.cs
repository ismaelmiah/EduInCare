using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateResultTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Results",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Results_StudentId",
                table: "Results",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Students_StudentId",
                table: "Results",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Students_StudentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_StudentId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Results");
        }
    }
}
