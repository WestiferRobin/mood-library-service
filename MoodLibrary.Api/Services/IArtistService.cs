using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> GetAllArtists();
        Task<ArtistDto> GetArtist(Guid artistId);
        Task AddArtist(ArtistDto artist);
        Task UpdateArtist(ArtistDto artist);
        Task DeleteArtist(Guid artistId);
    }
}