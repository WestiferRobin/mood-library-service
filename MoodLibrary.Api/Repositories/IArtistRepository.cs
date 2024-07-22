using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtist(Guid artistId);
        Task AddArtist(Artist artist);
        Task UpdateArtist(Artist artist);
        Task DeleteArtist(Artist artist);
    }
}