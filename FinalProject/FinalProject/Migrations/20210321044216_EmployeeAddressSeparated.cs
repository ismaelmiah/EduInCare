using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class EmployeeAddressSeparated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employees_EmployeeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_EmployeeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PresentAddress = table.Column<string>(nullable: true),
                    PermanentAddress = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<Guid>(nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Students_StudentId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropIndex(
                name: "IX_Address_StudentId",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

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
        }
    }
}
