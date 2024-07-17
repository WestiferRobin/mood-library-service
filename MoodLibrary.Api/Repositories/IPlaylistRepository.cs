using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAll();
        Task<Playlist> Get(Guid playlistId);
        Task Add(Playlist playlist);
        Task Update(Playlist playlist);
        Task Delete(Playlist playlist);
    }
}