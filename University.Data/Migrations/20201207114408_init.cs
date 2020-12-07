using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace University.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LectureTheaters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    NominatedCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureTheaters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true),
                    GivenDayOfWeek = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    LectureTheaterId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_LectureTheaters_LectureTheaterId",
                        column: x => x.LectureTheaterId,
                        principalTable: "LectureTheaters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lectures_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LectureTheaters",
                columns: new[] { "Id", "DeletedAt", "LastUpdate", "Name", "NominatedCapacity" },
                values: new object[,]
                {
                    { 1, null, null, "LectureTheater 1", 7 },
                    { 2, null, null, "LectureTheater 2", 4 },
                    { 3, null, null, "LectureTheater 3", 1 },
                    { 4, null, null, "LectureTheater 4", 4 },
                    { 5, null, null, "LectureTheater 5", 8 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DeletedAt", "FirstName", "LastName", "LastUpdate" },
                values: new object[,]
                {
                    { 1, null, "Student FirstName 1", "Student LastName 1", null },
                    { 2, null, "Student FirstName 2", "Student LastName 2", null },
                    { 3, null, "Student FirstName 3", "Student LastName 3", null },
                    { 4, null, "Student FirstName 4", "Student LastName 4", null },
                    { 5, null, "Student FirstName 5", "Student LastName 5", null }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "DeletedAt", "LastUpdate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Subject 1" },
                    { 2, null, null, "Subject 2" },
                    { 3, null, null, "Subject 3" },
                    { 4, null, null, "Subject 4" },
                    { 5, null, null, "Subject 5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_LectureTheaterId",
                table: "Lectures",
                column: "LectureTheaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_SubjectId",
                table: "Lectures",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_SubjectId",
                table: "StudentsSubjects",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "LectureTheaters");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
