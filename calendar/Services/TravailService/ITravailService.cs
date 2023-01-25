using calendar.ModelDTO;
using calendar.Models;

namespace calendar.Services.TravailService
{
    public interface ITravailService
    {
        Task<List<Travail>> GetAllTravails();
        Task<Travail> GetTravailById(string id);
        Task<Travail> AddTravail(TravailDTO travail);
        Task<Travail> UpdateTravail(string id, TravailDTO travail);
        Task<bool> DeleteTravail(string id);
    }
}
