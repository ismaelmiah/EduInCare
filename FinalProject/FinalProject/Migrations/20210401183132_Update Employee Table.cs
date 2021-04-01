using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class UpdateEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentImages_JobInfos_JobInfoId",
                table: "AppointmentImages");

            migrationBuilder.DropTable(
                name: "EmployeeEducations");

            migrationBuilder.DropTable(
                name: "EmploymentHistories");

            migrationBuilder.DropTable(
                name: "JobInfos");

            migrationBuilder.DropTable(
                name: "ExamTitles");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentImages_JobInfoId",
                table: "AppointmentImages");

            migrationBuilder.DropColumn(
                name: "JobInfoId",
                table: "AppointmentImages");

            migrationBuilder.AddColumn<Guid>(
                name: "CardId",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DesignationId",
                table: "Employees",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WorkShift",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Designations_DesignationId",
                table: "Employees",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Designations_DesignationId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShift",
                table: "Employees");

            migrationBuilder.AddColumn<Guid>(
                name: "JobInfoId",
                table: "AppointmentImages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DesignationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalLeave = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TitleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "EmployeeEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Achievement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cgpa = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    EducationLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marks = table.Column<float>(type: "real", nullable: false),
                    PassingYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultType = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<int>(type: "int", nullable: false)
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
                name: "FK_AppointmentImages_JobInfos_JobInfoId",
                table: "AppointmentImages",
                column: "JobInfoId",
                principalTable: "JobInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
