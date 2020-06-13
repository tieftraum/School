using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Infrastructure.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Course_Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Grade_Id", x => x.GradeId);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    SchoolClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.SchoolClassId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Teacher_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    DoB = table.Column<DateTime>(type: "date", nullable: true),
                    DoD = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Teacher_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Student_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    DoB = table.Column<DateTime>(type: "date", nullable: true),
                    DoD = table.Column<DateTime>(type: "date", nullable: true),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Student_ID);
                    table.ForeignKey(
                        name: "FK_Students_SchoolClasses_ClassId",
                        column: x => x.ClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "SchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Title",
                table: "Courses",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Grade",
                table: "Grades",
                column: "Grade",
                unique: true,
                filter: "[Grade] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_Name",
                table: "SchoolClasses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "SchoolClasses");
        }
    }
}
