using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassInfoControll.Migrations
{
    public partial class InitialCreateSQLite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduleItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FacultyName = table.Column<string>(type: "TEXT", nullable: false),
                    ClassTime = table.Column<string>(type: "TEXT", nullable: false),
                    GroupNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Teacher = table.Column<string>(type: "TEXT", nullable: false),
                    AlmUsage = table.Column<string>(type: "TEXT", nullable: false),
                    SyllabusAvailability = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAttendances",
                columns: table => new
                {
                    ScheduleItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    PresentStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    AttendanceRate = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttendances", x => x.ScheduleItemId);
                    table.ForeignKey(
                        name: "FK_StudentAttendances_ScheduleItems_ScheduleItemId",
                        column: x => x.ScheduleItemId,
                        principalTable: "ScheduleItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAttendances");

            migrationBuilder.DropTable(
                name: "ScheduleItems");
        }
    }
}
