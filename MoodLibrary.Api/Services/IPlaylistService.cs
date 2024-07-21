using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDto>> GetAll();
        Task<PlaylistDto> Get(Guid playlistId);
        Task Add(PlaylistDto playlist);
        Task Update(PlaylistDto playlist);
        Task Delete(Guid playlistId);
    }
}