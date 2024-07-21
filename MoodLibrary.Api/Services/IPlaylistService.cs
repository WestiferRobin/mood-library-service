using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Services
{
    public interface IPlaylistService
    {
        Task<IEnumerable<PlaylistDto>> GetAllPlaylists();
        Task<PlaylistDto> GetPlaylist(Guid playlistId);
        Task AddPlaylist(PlaylistDto playlist);
        Task UpdatePlaylist(PlaylistDto playlist);
        Task DeletePlaylist(Guid playlistId);
    }
}