using shifts_logger.Models;

namespace shifts_logger.Interfaces
{
    public interface IShiftLogsRepository
    {
        ICollection<ShiftLogs> GetShiftLogs();
        ShiftLogs GetShiftLog(int id);
        bool ShiftLogExists(int id);
        bool InsertShiftLog(ShiftLogs shiftLog);
        public bool UpdateShiftLog(ShiftLogs shiftlog);
        public bool DeleteShiftLog(int id);
    }
}
