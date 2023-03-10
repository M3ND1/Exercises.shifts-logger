using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using shifts_logger.Models;

namespace shifts_logger.Data
{
    public class ShiftLogsContext : DbContext
    {
        public ShiftLogsContext(DbContextOptions options) : base(options) { }

        public DbSet<ShiftLogs> shiftLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShiftLogs>()
                .Property(p => p.StartTime)
                .HasColumnType("datetime2(0)");

            modelBuilder.Entity<ShiftLogs>()
                .Property(p => p.EndTime)
                .HasColumnType("datetime2(0)");
        }
    }
}
