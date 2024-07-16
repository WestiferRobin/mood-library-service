using MoodLibraryApi.Models;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository repository;

        public PlaylistService(IPlaylistRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Playlist>> GetAllModels()
        {
            return await repository.GetAll();
        }
    }
}