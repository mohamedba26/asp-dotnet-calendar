using calendar.Models;

namespace calendar.Services.MissionService
{
    public class MissionService : IMissionService
    {
        private readonly DataContext _context;
        public MissionService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Mission>> GetAllMissions()
        {
            var mission = await _context.Missions.ToListAsync();
            return mission;
        }

        public async Task<Mission> GeMissionById(string id)
        {
            var mission = await _context.Missions.Where(t => t.id == id).FirstOrDefaultAsync();
            return mission;
        }
        public async Task<Mission> AddMission(Mission mission)
        {
            Guid guid = Guid.NewGuid();
            mission.id = guid.ToString();
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();
            return mission;
        }
        public async Task<Mission> UpdateMission(string id, Mission missionRequest)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
                return null;
            mission.libelle = missionRequest.libelle;
            await _context.SaveChangesAsync();
            return mission;
        }

        public async Task<bool> DeleteMission(string id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission == null)
                return false;
            _context.Missions.Remove(mission);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
