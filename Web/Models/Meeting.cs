using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string DocumentURL { get; set; }
    }
}
