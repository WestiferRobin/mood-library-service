using MoodLibraryApi.Models.Songs;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
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