using System.ComponentModel.DataAnnotations;

namespace ZooBitatApi.Models
{
    public class Log
    {
        
        [Key]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Level { get; set; }
        public string Section { get; set; }
    }
}
