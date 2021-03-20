using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class RelationshipDefinedFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headers_Images_ImageId",
                table: "Headers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_EnrollCourseId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Parents_ParentsInfoId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_PermanentAddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Images_PhotoImageId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_PresentAddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_EnrollCourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ParentsInfoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PermanentAddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PhotoImageId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_PresentAddressId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Headers_ImageId",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "EnrollCourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsInfoId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermanentAddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhotoImageId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PresentAddressId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentsId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Headers",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentAddress",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

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
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Headers_Images_ImageId",
                table: "Headers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
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
                name: "IX_Students_CourseId",
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
                name: "CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PresentAddress",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "EnrollCourseId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentsInfoId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PermanentAddressId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoImageId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PresentAddressId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Headers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_EnrollCourseId",
                table: "Students",
                column: "EnrollCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentsInfoId",
                table: "Students",
                column: "ParentsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PermanentAddressId",
                table: "Students",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PhotoImageId",
                table: "Students",
                column: "PhotoImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_PresentAddressId",
                table: "Students",
                column: "PresentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Headers_ImageId",
                table: "Headers",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Headers_Images_ImageId",
                table: "Headers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_EnrollCourseId",
                table: "Students",
                column: "EnrollCourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Parents_ParentsInfoId",
                table: "Students",
                column: "ParentsInfoId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_PermanentAddressId",
                table: "Students",
                column: "PermanentAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Images_PhotoImageId",
                table: "Students",
                column: "PhotoImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_PresentAddressId",
                table: "Students",
                column: "PresentAddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
