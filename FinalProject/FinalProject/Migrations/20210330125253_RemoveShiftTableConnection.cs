using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class RemoveShiftTableConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Shifts_ShiftId",
                table: "Registrations");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_ShiftId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Registrations");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "Registrations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "Registrations");

            migrationBuilder.AddColumn<Guid>(
                name: "ShiftId",
                table: "Registrations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ShiftId",
                table: "Registrations",
                column: "ShiftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Shifts_ShiftId",
                table: "Registrations",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
