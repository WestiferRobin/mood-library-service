using MoodLibraryApi.Dtos;

namespace MoodLibraryApi.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDto>> GetAll();
        Task<AlbumDto> GetAlbum(Guid albumId);
        Task<SongDto> GetSongs(Guid albumId);
        Task AddAlbum(AlbumDto album);
        Task AddSongs(List<SongDto> songs);
        // Task UpdateAlbum(Guid id, AlbumDto album);
        Task DeleteAlbum(Guid id);
    }
}