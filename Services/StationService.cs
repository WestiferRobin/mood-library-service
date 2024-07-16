using MoodLibraryApi.Models;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
{
    public class StationService : IStationService
    {
        private readonly IStationRepository repository;

        public StationService(
            IStationRepository repository
        )
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Station>> GetAllModels()
        {
            return await repository.GetAll();
        }
    }
}