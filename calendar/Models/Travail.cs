using System.ComponentModel.DataAnnotations;

namespace calendar.Models
{
    public class Travail
    {
        public string id { get; set; }
        [Required]
        public DateTime start { get; set; }
        [Required]
        public DateTime end { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string ClientId { get; set; }
        public Client client { get; set; }
        public string MissionId { get; set; }
        public Mission mission { get; set; }

        public string description { get; set; }
        public string color { get; set; }
    }
}
