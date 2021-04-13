using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class ApplicantsTableInitialized_And_StudentTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Registrations");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    BirthCertificateNo = table.Column<string>(nullable: true),
                    NationalIdentificationNo = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    ImageAlternativeText = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    CourseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
