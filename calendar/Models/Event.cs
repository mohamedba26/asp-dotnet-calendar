using System.ComponentModel.DataAnnotations;

namespace calendar.Models
{
    public  abstract class Event
    {
        public abstract string id { get; set; }
        [Required]
        public abstract DateTime start { get; set; }
        [Required]
        public abstract DateTime end { get; set; }
        public abstract string title { get; set; }
        public abstract string type { get; set; }
        public abstract string color { get; set; }
    }
}