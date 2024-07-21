using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAllAlbums();
        Task<AlbumDto> GetAlbum(Guid albumId);
        Task AddAlbum(AlbumDto album);
        Task UpdateAlbum(AlbumDto album);
        Task DeleteAlbum(Guid albumId);
    }
}