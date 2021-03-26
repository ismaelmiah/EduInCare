using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class DepartmentEmployeeTableInitializedImageTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "HeaderImage");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "HeaderId",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Courses",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Address",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NationalIdentificationNo = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    JoinOfDate = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_HeaderId",
                table: "Images",
                column: "HeaderId",
                unique: true,
                filter: "[HeaderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeeId",
                table: "Departments",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employees_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employees_EmployeeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Images_HeaderId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_StudentId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Address_EmployeeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Images_StudentId",
                table: "Images",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeaderImage_HeaderId",
                table: "HeaderImage",
                column: "HeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Students_StudentId",
                table: "Images",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
