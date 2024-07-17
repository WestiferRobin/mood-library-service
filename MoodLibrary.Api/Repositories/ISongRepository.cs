using MoodLibrary.Api.Models.Songs;

namespace MoodLibrary.Api.Repositories
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAll();
        Task<Song> Get(Guid songId);
        Task Add(Song Song);
        Task Update(Song Song);
        Task Delete(Song Song);
    }
}