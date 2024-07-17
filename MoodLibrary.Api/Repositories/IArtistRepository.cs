using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> Get(Guid artistId);
        Task Add(Artist artist);
        Task Update(Artist artist);
        Task Delete(Artist artist);
    }
}