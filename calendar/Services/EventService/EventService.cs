using calendar.Models;

namespace calendar.Services.EventService
{
    public class EventService:IEventService
    {
        private static List<Event> Events= new List<Event>();
        public List<Event> GetAllEvents() { return Events; }
        public Event GetEventById(string id)
        {
            var ev=Events.Find(x=>x.id==id);
            return ev;
        }
        public Event AddEvent(Event ev)
        {
            Guid guid= Guid.NewGuid();
            ev.id = guid.ToString();
            Events.Add(ev);
            return ev;
        }
        public Event UpdateEvent(string id,Event requestEv)
        {
            var ev = Events.Find(x => x.id == id);
            if(ev==null)
                return null;
            ev.start= requestEv.start;
            ev.end= requestEv.end;
            if(requestEv.type!="")
                ev.type= requestEv.type;
            if (requestEv.title != "")
                ev.title= requestEv.title;
            if (requestEv.color != "")
                ev.color= requestEv.color;
            return ev;
        }
        public bool DeleteEvent(string id) 
        {
            var ev = Events.Find(x => x.id == id);
            if (ev == null) { return false; }
            Events.Remove(ev);
            return true;
        }
    }
}
