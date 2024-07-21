using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IStationService
    {
        Task<IEnumerable<StationDto>> GetAll();
        Task<StationDto> Get(Guid stationId);
        Task Add(StationDto station);
        Task Update(StationDto station);
        Task Delete(Guid stationId);
    }
}