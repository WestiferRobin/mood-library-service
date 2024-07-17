using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAllModels();
        Task<IEnumerable<AlbumDto>> GetAll();
        Task<Album> GetAlbumModel(Guid albumId);
        Task<AlbumDto> GetAlbum(Guid albumId);
        Task AddAlbum(AlbumDto album);
        Task DeleteAlbum(Guid id);
    }
}