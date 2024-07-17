using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;

namespace MoodLibrary.Api.Services
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