using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json.Bson;
using shifts_logger.Data;
using shifts_logger.Interfaces;
using shifts_logger.Models;

namespace shifts_logger.Repository
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ShiftLogsRepository : IShiftLogsRepository
    {
        private readonly ShiftLogsContext _context;
        public ShiftLogsRepository(ShiftLogsContext context) 
        {
            _context = context;
        }

        public ShiftLogs GetShiftLog(int id)
        {
           return _context.shiftLogs.Where(sl => sl.ID == id).FirstOrDefault();
        }

        public ICollection<ShiftLogs> GetShiftLogs()
        {
            return _context.shiftLogs.OrderBy(id => id.ID).ToList();
        }

        public bool InsertShiftLog(ShiftLogs shiftLog)
        {
            _context.Add(
                new ShiftLogs
                {
                    Name = shiftLog.Name,
                    Description = shiftLog.Description,
                    StartTime = shiftLog.StartTime,
                    EndTime = shiftLog.EndTime
                });


            return Save();
        }

        public bool ShiftLogExists(int id)
        {
            return _context.shiftLogs.Any(sl => sl.ID == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        public bool UpdateShiftLog(ShiftLogs shiftLogs)
        {
            var product_id = _context.shiftLogs.FirstOrDefault(sl => sl.ID == shiftLogs.ID);
            
            if (product_id != null)
            {
                product_id.Name = shiftLogs.Name;
                product_id.Description = shiftLogs.Description;
                product_id.StartTime = shiftLogs.StartTime;
                product_id.EndTime = shiftLogs.EndTime;
                return Save();
            }
            return Save();
        }
        public bool DeleteShiftLog(int id)
        {
            var deleted_id = _context.shiftLogs.FirstOrDefault(sl => sl.ID == id);

            if(deleted_id != null)
            {
                _context.Remove(deleted_id);
                return Save();
            }
            return Save();
        }
    }
}
