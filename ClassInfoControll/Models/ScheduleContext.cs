using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class ScheduleContext : DbContext
{
    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    public DbSet<ScheduleItems> ScheduleItems { get; set; } = null!;
}