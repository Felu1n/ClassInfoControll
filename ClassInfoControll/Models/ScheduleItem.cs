namespace TodoApi.Models;

public class ScheduleItems
{
    public int Id { get; set; }
    public string FacultyName { get; set; }
    public string ClassTime { get; set; }
    public string GroupNumber { get; set; }
    public string Subject { get; set; }
    public string Teacher { get; set; }
    public string AlmUsage { get; set; }
    public string SyllabusAvailability { get; set; }
    public StudentAttendance StudentAttendance { get; set; }
}

public class StudentAttendance
{
    public int TotalStudents { get; set; }
    public int PresentStudents { get; set; }
    public double AttendanceRate { get; set; }
}