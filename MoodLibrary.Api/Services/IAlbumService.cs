using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAll();
        Task<AlbumDto> Get(Guid albumId);
        Task Add(AlbumDto album);
        Task Update(AlbumDto album);
        Task Delete(Guid albumId);
    }
}