using MoodLibraryApi.Dtos;
using MoodLibraryApi.Models;

namespace MoodLibraryApi.Services
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