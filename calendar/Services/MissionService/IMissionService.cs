using calendar.Models;

namespace calendar.Services.MissionService
{
    public interface IMissionService
    {
        Task<List<Mission>> GetAllMissions();
        Task<Mission> GeMissionById(string id);
        Task<Mission> AddMission(Mission mission);
        Task<Mission> UpdateMission(string id, Mission mission);
        Task<bool> DeleteMission(string id);
    }
}
