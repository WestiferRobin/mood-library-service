using MoodLibraryApi.Models;

namespace MoodLibraryApi.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAllModels();
    }
}