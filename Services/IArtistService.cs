using MoodLibraryApi.Dtos;

namespace MoodLibraryApi.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> GetAll();
        Task<ArtistDto> GetArtist(Guid artistId);
        Task<DiscographyDto> GetDiscography(Guid artistId);
        // 
        // Task AddArtist(AddArtistRequestDto artist);
        // Task UpdateArtist(UpdateArtistRequestDto request);
        // Task DeleteArtist(Guid id);
    }
}