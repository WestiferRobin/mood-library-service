using MoodLibraryApi.Models;

namespace MoodLibraryApi.Services
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAllModels();
    }
}