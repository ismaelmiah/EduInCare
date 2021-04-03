using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class EmployeeTableGetOnPreviousState1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "CardId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CardId",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
