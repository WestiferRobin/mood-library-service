using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllModels();
        Task<IEnumerable<ArtistDto>> GetAll();
        Task<ArtistDto> GetArtist(Guid artistId);
        Task<DiscographyDto> GetDiscography(Guid artistId);
        Task AddArtist(ArtistDto artist);
        Task AddDiscography(DiscographyDto discography);
        Task UpdateArtist(Guid id, ArtistDto artist);
        Task DeleteArtist(Guid id);
    }
}