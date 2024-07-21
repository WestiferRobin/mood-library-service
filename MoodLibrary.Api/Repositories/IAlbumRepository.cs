using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAll();
        Task<Album> Get(Guid albumId);
        Task Add(Album album);
        Task Update(Album album);
        Task Delete(Album album);
    }
}