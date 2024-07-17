using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IStationRepository
    {
        Task<IEnumerable<Station>> GetAll();
        Task<Station> Get(Guid stationId);
        Task Add(Station Station);
        Task Update(Station Station);
        Task Delete(Station Station);
    }
}