using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class StudentImageCantbenull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
