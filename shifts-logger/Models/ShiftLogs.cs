using System.ComponentModel.DataAnnotations;

namespace shifts_logger.Models
{
    public class ShiftLogs
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
    }
}
