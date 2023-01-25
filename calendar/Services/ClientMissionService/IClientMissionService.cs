using calendar.Models;

namespace calendar.Services.ClientMissionService
{
    public interface IClientMissionService
    {
        Task<List<ClientMission>> GetAllRelations();
        Task<List<ClientMission>> GetMissionsByClientId(string id);
        Task<ClientMission> AddRelation(ClientMission relation);
        Task<bool> DeleteRelation(ClientMission relation);
    }
}
