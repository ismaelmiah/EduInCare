using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class StudentImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PhotoImageId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_PhotoImageId",
                table: "Students",
                column: "PhotoImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Images_PhotoImageId",
                table: "Students",
                column: "PhotoImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Images_PhotoImageId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PhotoImageId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhotoImageId",
                table: "Students");
        }
    }
}
