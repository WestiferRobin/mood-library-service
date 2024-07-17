using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;

namespace MoodLibrary.Api.Services
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