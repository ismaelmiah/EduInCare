using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateResultTabel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SectionId",
                table: "Results",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Results_SectionId",
                table: "Results",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Sections_SectionId",
                table: "Results",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Sections_SectionId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_SectionId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Results");
        }
    }
}
