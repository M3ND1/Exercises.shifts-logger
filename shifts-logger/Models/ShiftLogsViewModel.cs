namespace shifts_logger.Models
{
    public class ShiftLogsViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; } 
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
