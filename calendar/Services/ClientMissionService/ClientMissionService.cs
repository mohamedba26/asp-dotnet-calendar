using calendar.Models;

namespace calendar.Services.ClientMissionService
{
    public class ClientMissionService : IClientMissionService
    {

        private readonly DataContext _context;
        public ClientMissionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ClientMission>> GetAllRelations()
        {
            var relation = await _context.ClientMissions.ToListAsync();
            return relation;
        }
        public async Task<List<ClientMission>> GetMissionsByClientId(string id)
        {
            var relation = await _context.ClientMissions.Where(r=>r.clientID==id).Include(r=>r.mission).ToListAsync();
            return relation;
        }

        public async Task<ClientMission> AddRelation(ClientMission relation)
        {
            var rel= await _context.ClientMissions.Where(r => (r.clientID == relation.clientID && r.MissionID == relation.MissionID)).Include(r => r.mission).ToListAsync();
            if(rel.Count()!=0)
                return null;
            relation.client = null;
            relation.mission = null;
            await _context.ClientMissions.AddAsync(relation);
            await _context.SaveChangesAsync();
            return relation;
        }

        public async Task<bool> DeleteRelation(ClientMission relation)
        {
            var rel = await _context.ClientMissions.Where(r => (r.clientID == relation.clientID && r.MissionID == relation.MissionID)).Include(r => r.mission).ToListAsync();
            if (rel.Count() == 0)
                return false;
            _context.ClientMissions.Remove(rel[0]);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
