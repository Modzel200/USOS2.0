using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace USOS.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    LecturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AcademicTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.LecturerID);
                });

            migrationBuilder.CreateTable(
                name: "MajorSubjects",
                columns: table => new
                {
                    MajorSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorSubjects", x => x.MajorSubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ShortDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MajorSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_MajorSubjects_MajorSubjectID",
                        column: x => x.MajorSubjectID,
                        principalTable: "MajorSubjects",
                        principalColumn: "MajorSubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LecturerSubjects",
                columns: table => new
                {
                    LecturerID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerSubjects", x => new { x.LecturerID, x.SubjectID });
                    table.ForeignKey(
                        name: "FK_LecturerSubjects_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "LecturerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectMajorSubjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    MajorSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectMajorSubjects", x => new { x.SubjectID, x.MajorSubjectID });
                    table.ForeignKey(
                        name: "FK_SubjectMajorSubjects_MajorSubjects_MajorSubjectID",
                        column: x => x.MajorSubjectID,
                        principalTable: "MajorSubjects",
                        principalColumn: "MajorSubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectMajorSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LecturerSubjects_SubjectID",
                table: "LecturerSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_MajorSubjectID",
                table: "Students",
                column: "MajorSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectMajorSubjects_MajorSubjectID",
                table: "SubjectMajorSubjects",
                column: "MajorSubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturerSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectMajorSubjects");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "MajorSubjects");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
