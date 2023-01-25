using calendar.ModelDTO;
using calendar.Models;
using System.Threading.Tasks;

namespace calendar.Services.ClientService
{
    public interface IClientService
    {
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(string id);
        Task<Client> AddClient(Client client);
        Task<Client> UpdateClient(string id, Client client);
        Task<bool> DeleteClient(string id);
    }
}
