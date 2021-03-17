using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Web.Migrations
{
    public partial class ModifiedRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_HeaderId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "HeaderImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    AlternativeText = table.Column<string>(nullable: true),
                    HeaderId = table.Column<Guid>(nullable: false)
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
                name: "IX_HeaderImage_HeaderId",
                table: "HeaderImage",
                column: "HeaderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeaderImage");

            migrationBuilder.AddColumn<Guid>(
                name: "HeaderId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Images_HeaderId",
                table: "Images",
                column: "HeaderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Headers_HeaderId",
                table: "Images",
                column: "HeaderId",
                principalTable: "Headers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
