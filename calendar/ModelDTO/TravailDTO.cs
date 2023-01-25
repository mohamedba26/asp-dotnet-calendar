using calendar.Models;

namespace calendar.ModelDTO
{
    public class TravailDTO:Event
    {
        private string _id;
        private DateTime _start;
        private DateTime _end;
        private string _title="";
        private string _type="";
        private string _color = "";
        public string description { get; set; } = "";
        public string ClientId { get; set; } = "";
        public string MissionId { get; set; } = "";

        public override string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override DateTime start
        {
            get { return _start; }
            set { _start = value; }
        }

        public override DateTime end
        {
            get { return _end; }
            set { _end = value; }
        }

        public override string title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public override string color
        {
            get { return _color; }
            set { _color = value; }
        }
        
        public static TravailDTO ToTravailDTO(Travail travail)
        {
            return new TravailDTO
            {
                id = travail.id,
                start = travail.start,
                end = travail.end,
                title = travail.title,
                description = travail.description,
                type=travail.type,
                color = travail.color,
                ClientId = travail.ClientId,
                MissionId= travail.MissionId
            };
        }
        public Travail toTravail()
        {
            return new Travail
            {
                id = id,
                start = start,
                end = end,
                title = title,
                description = description,
                type=type,
                color = color,
                ClientId = ClientId,
                MissionId = MissionId
            };
        }
    }
}
