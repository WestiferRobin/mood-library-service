using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Dtos.Responses;

namespace MoodLibrary.Api.Services
{
    public interface ISearchService
    {
        Task<SearchResponseDto> GetAllItems();
        Task<IEnumerable<SearchItemDto>> GetAllArtists();
        Task<IEnumerable<SearchItemDto>> GetAllAlbums();
        Task<IEnumerable<SearchItemDto>> GetAllPlaylists();
        Task<IEnumerable<SearchItemDto>> GetAllStations();
        Task<IEnumerable<SearchItemDto>> GetAllSongs();
    }
}