using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using shifts_logger.Models;

namespace shifts_logger.Data
{
    public class ShiftLogsContext : DbContext
    {
        public ShiftLogsContext(DbContextOptions options) : base(options) { }

        public DbSet<ShiftLogs> shiftLogs { get; set; }
    }
}
