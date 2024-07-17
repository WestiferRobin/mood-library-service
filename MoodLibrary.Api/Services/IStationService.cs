using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Services
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAllModels();
    }
}