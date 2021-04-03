using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class EmployeeTableGetOnPreviousState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LeavingDate",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkShift",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeavingDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkShift",
                table: "Employees");
        }
    }
}
