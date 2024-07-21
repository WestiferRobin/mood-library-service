using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAll();
        Task<Station> Get(Guid stationId);
        Task Add(Station station);
        Task Update(Station station);
        Task Delete(Station station);
    }
}