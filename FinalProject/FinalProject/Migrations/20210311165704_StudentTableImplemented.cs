using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class StudentTableImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    FatherMobileNo = table.Column<string>(nullable: true),
                    FatherOccupation = table.Column<string>(nullable: true),
                    FatherAnnualIncome = table.Column<double>(nullable: false),
                    MotherName = table.Column<string>(nullable: true),
                    MotherMobileNo = table.Column<string>(nullable: true),
                    MotherOccupation = table.Column<string>(nullable: true),
                    GuardianName = table.Column<string>(nullable: true),
                    GuardianMobileNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    BirthCertificateNo = table.Column<string>(nullable: true),
                    NationalIdentificationNo = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    PresentAddressId = table.Column<Guid>(nullable: true),
                    PermanentAddressId = table.Column<Guid>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    YearOfEnroll = table.Column<DateTime>(nullable: false),
                    ParentsInfoId = table.Column<Guid>(nullable: true),
                    EnrollCourseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_EnrollCourseId",
                        column: x => x.EnrollCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Parents_ParentsInfoId",
                        column: x => x.ParentsInfoId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_PermanentAddressId",
                        column: x => x.PermanentAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_PresentAddressId",
                        column: x => x.PresentAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_Students_PresentAddressId",
                table: "Students",
                column: "PresentAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
