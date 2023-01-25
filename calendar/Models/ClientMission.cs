using System.ComponentModel.DataAnnotations;

namespace calendar.Models
{
    public class ClientMission
    {
        [Key]
        public string clientID { get; set; }
        public Client client { get; set; }
        [Key]
        public string MissionID { get; set; }
        public Mission mission { get; set; }
    }
}
