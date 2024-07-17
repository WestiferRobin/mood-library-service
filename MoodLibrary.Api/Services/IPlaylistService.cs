using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<Playlist>> GetAllModels();
    }
}