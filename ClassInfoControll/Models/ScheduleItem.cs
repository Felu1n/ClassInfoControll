using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassInfoControll.Models
{
    public class ScheduleItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FacultyName { get; set; }

        [Required]
        public string ClassTime { get; set; }

        [Required]
        public string GroupNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Teacher { get; set; }

        [Required]
        public string AlmUsage { get; set; }

        [Required]
        public string SyllabusAvailability { get; set; }

        [Required]
        public StudentAttendance StudentAttendance { get; set; }
    }

    public class StudentAttendance
    {
        public int TotalStudents { get; set; }

        public int PresentStudents { get; set; }

        public double AttendanceRate { get; set; }
    }
}

