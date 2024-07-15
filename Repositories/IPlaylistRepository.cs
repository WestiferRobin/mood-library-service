using MoodLibraryApi.Models;

namespace MoodLibraryApi.Repositories
{
    public interface IPlaylistRepository
    {
        Task<IEnumerable<Playlist>> GetAll();
        Task<Playlist> GetById(Guid id);
        Task Add(Playlist playlist);
        Task Update(Playlist playlist);
        Task DeleteById(Guid id);
    }
}