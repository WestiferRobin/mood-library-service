using MoodLibraryApi.Dtos;
using MoodLibraryApi.Dtos.Responses;

namespace MoodLibraryApi.Services
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