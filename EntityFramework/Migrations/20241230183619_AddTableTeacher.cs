using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddTableTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Courses",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "CourseRegisters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    EMail = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegisters",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_StudentId",
                table: "CourseRegisters",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegisters_TeacherId",
                table: "CourseRegisters",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Students_StudentId",
                table: "CourseRegisters",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Teachers_TeacherId",
                table: "CourseRegisters",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Students_StudentId",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Teachers_TeacherId",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegisters");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegisters_StudentId",
                table: "CourseRegisters");

            migrationBuilder.DropIndex(
                name: "IX_CourseRegisters_TeacherId",
                table: "CourseRegisters");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "CourseRegisters");
        }
    }
}
