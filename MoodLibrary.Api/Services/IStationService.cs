using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IStationService
    {
        Task<IEnumerable<StationDto>> GetAllStations();
        Task<StationDto> GetStation(Guid stationId);
        Task AddStation(StationDto station);
        Task UpdateStation(StationDto station);
        Task DeleteStation(Guid stationId);
    }
}