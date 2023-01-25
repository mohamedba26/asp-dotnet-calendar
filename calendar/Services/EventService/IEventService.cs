using calendar.Models;

namespace calendar.Services.EventService
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        Event GetEventById(string id);
        Event AddEvent(Event ev);
        Event UpdateEvent(string id,Event ev);
        bool DeleteEvent(string id);
    }
}
