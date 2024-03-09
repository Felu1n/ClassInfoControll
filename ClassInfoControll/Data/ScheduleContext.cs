using ClassInfoControll.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassInfoControll.Data
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext(DbContextOptions<ScheduleContext> options)
            : base(options)
        {
        }

        public DbSet<ScheduleItem> ScheduleItems { get; set; }

        public DbSet<StudentAttendance> StudentAttendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleItem>(entity =>
            {
                entity.OwnsOne(s => s.StudentAttendance);
            });
        }
    }
}
