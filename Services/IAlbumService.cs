using MoodLibraryApi.Dtos;
using MoodLibraryApi.Models;

namespace MoodLibraryApi.Services
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