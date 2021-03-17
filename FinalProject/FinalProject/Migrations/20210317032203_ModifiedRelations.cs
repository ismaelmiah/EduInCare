using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class ModifiedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headers_Images_ImageId",
                table: "Headers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Images_ImageId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ImageId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentsId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Headers_ImageId",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Students");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Parents",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "HeaderId",
                table: "Images",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Images",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Parents_StudentId",
                table: "Parents",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_HeaderId",
                table: "Images",
                column: "HeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parents_Students_StudentId",
                table: "Parents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Students_StudentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Parents_Students_StudentId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Parents_StudentId",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Images_HeaderId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Parents");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentsId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ImageId",
                table: "Students",
                column: "ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentsId",
                table: "Students",
                column: "ParentsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Headers_ImageId",
                table: "Headers",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Headers_Images_ImageId",
                table: "Headers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Images_ImageId",
                table: "Students",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentsId",
                table: "Students",
                column: "ParentsId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
