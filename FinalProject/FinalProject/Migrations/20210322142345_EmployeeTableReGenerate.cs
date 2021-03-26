using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class EmployeeTableReGenerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "EmployeeImage");

            migrationBuilder.DropTable(
                name: "HeaderImage");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "EmployeeType",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalIdentificationNo",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlternativeText",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentAddress",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAlternativeText",
                table: "Headers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Headers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageAlternativeText",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nid",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentAddress",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Religion",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EducationLevelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyLocation = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DesignationId = table.Column<Guid>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false),
                    TotalLeave = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobInfos_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TitleName = table.Column<string>(nullable: true),
                    EducationLevelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTitles_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AlternativeText = table.Column<string>(nullable: true),
                    JobInfoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentImages_JobInfos_JobInfoId",
                        column: x => x.JobInfoId,
                        principalTable: "JobInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EducationLevelId = table.Column<Guid>(nullable: false),
                    ExamTitleId = table.Column<Guid>(nullable: false),
                    Major = table.Column<string>(nullable: true),
                    InstituteName = table.Column<string>(nullable: true),
                    ResultType = table.Column<int>(nullable: false),
                    Cgpa = table.Column<float>(nullable: false),
                    Scale = table.Column<int>(nullable: false),
                    Marks = table.Column<float>(nullable: false),
                    PassingYear = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Achievement = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_EducationLevels_EducationLevelId",
                        column: x => x.EducationLevelId,
                        principalTable: "EducationLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeEducations_ExamTitles_ExamTitleId",
                        column: x => x.ExamTitleId,
                        principalTable: "ExamTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentImages_JobInfoId",
                table: "AppointmentImages",
                column: "JobInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EducationLevelId",
                table: "EmployeeEducations",
                column: "EducationLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_EmployeeId",
                table: "EmployeeEducations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEducations_ExamTitleId",
                table: "EmployeeEducations",
                column: "ExamTitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_EmployeeId",
                table: "EmploymentHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTitles_EducationLevelId",
                table: "ExamTitles",
                column: "EducationLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_DesignationId",
                table: "JobInfos",
                column: "DesignationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobInfos_EmployeeId",
                table: "JobInfos",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "AppointmentImages");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmploymentHistories");

            migrationBuilder.DropTable(
                name: "JobInfos");

            migrationBuilder.DropTable(
                name: "ExamTitles");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropColumn(
                name: "ImageAlternativeText",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PresentAddress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImageAlternativeText",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Headers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImageAlternativeText",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nid",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PresentAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Religion",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "DepartmentId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeType",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalIdentificationNo",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternativeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeImage_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeaderImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternativeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeaderImage_Headers_HeaderId",
                        column: x => x.HeaderId,
                        principalTable: "Headers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlternativeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeImage_EmployeeId",
                table: "EmployeeImage",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeaderImage_HeaderId",
                table: "HeaderImage",
                column: "HeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
