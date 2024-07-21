using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto>> GetAll();
        Task<ArtistDto> Get(Guid artistId);
        Task Add(ArtistDto artist);
        Task Update(ArtistDto artist);
        Task Delete(Guid artistId);
    }
}