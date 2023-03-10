using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Linq;
using shifts_logger.Data;
using shifts_logger.Models;

namespace shifts_logger.SeedData
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ShiftLogsContext(
                serviceProvider.GetRequiredService<DbContextOptions<ShiftLogsContext>>());

            // Check if data already exists
            if (context.shiftLogs.Any())
            {
                return;   // Data already seeded
            }

            // Create new data
            var logs = new ShiftLogs[]
            {
                new ShiftLogs
                {
                    Name = "Shift 1",
                    Description = "First shift",
                    StartTime = DateTime.ParseExact("01/01/2000 08:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact("01/01/2000 16:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                },
                new ShiftLogs
                {
                    Name = "Shift 2",
                    Description = "Second shift",
                    StartTime = DateTime.ParseExact("02/01/2000 16:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact("03/01/2000 00:00", "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                }
            };

            context.shiftLogs.AddRange(logs);
            context.SaveChanges();
        }
    }
}
