using MoodLibrary.Api.Models.Songs;
using MoodLibrary.Api.Repositories;

namespace MoodLibrary.Api.Services
{
    public class SongService : ISongService
    {
        private readonly ISongRepository repository;

        public SongService(
            ISongRepository repository
        )
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Song>> GetAllModels()
        {
            return await repository.GetAll();
        }
    }
}