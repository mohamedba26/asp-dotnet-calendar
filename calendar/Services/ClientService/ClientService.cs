using calendar.ModelDTO;
using calendar.Models;

namespace calendar.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly DataContext _context;
        public ClientService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllClients()
        {
            var client = await _context.Clients.ToListAsync();
            return client;
        }

        public async Task<Client> GetClientById(string id)
        {
            var client = await _context.Clients.Where(t => t.id == id).FirstOrDefaultAsync();
            return client;
        }

        public async Task<Client> AddClient(Client client)
        {
            Guid guid = Guid.NewGuid();
            client.id = guid.ToString();
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return client;
        }


        public async Task<Client> UpdateClient(string id, Client clientRequest)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return null;
            client.libelle =clientRequest.libelle;
            await _context.SaveChangesAsync();
            return client;
        }
        public async Task<bool> DeleteClient(string id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
                return false;
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
