using calendar.ModelDTO;
using calendar.Models;

namespace calendar.Services.TravailService
{
    public class TravailService: ITravailService
    {
        private readonly DataContext _context;
        public TravailService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Travail>> GetAllTravails()
        {
            var travail = await _context.Travails.Include(x => x.client).Include(x => x.mission).ToListAsync();
            return travail;
        }
        public async Task<Travail> GetTravailById(string id)
        {
            var travail = await _context.Travails.Include(x => x.client).Include(x => x.mission).Where(t => t.id == id).FirstOrDefaultAsync();
            return travail;
        }
        public async Task<Travail> AddTravail(TravailDTO travaildto)
        {
            Guid guid = Guid.NewGuid();
            travaildto.id = guid.ToString();
            Travail travail = travaildto.toTravail();
            await _context.Travails.AddAsync(travail);
            await _context.SaveChangesAsync();
            return travail;
        }
        public async Task<Travail> UpdateTravail(string id, TravailDTO travaildto)
        {
            Travail travail = await _context.Travails.FindAsync(id);
            if (travail == null)
                return travail;
            var t = travaildto.toTravail();
            travail.start=t.start;
            travail.end=t.end;
            if (t.title != "")
            {
                travail.title = t.title;
                travail.description = t.description;
                travail.type = t.type;
                travail.color = t.color;
                travail.ClientId = t.ClientId;
                travail.MissionId = t.MissionId;
            }
            await _context.SaveChangesAsync();
            return travail;
        }
        public async Task<bool> DeleteTravail(string id)
        {
            var travail = await _context.Travails.FindAsync(id);
            if (travail == null)
                return false;
            _context.Travails.Remove(travail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
