using MoodLibraryApi.Models;

namespace MoodLibraryApi.Services
{
    public interface ILibraryService
    {
        #region Artist Methods
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Artist> GetArtistById(Guid artistId);
        #endregion

        #region Album Methods
        Task<IEnumerable<Album>> GetAllAlbums();
        Task<Album> GetAlbumById(Guid albumId);
        Task<IEnumerable<Album>> GetArtistAlbumsById(Guid artistId);
        #endregion

        #region  Song Methods
        Task<IEnumerable<Song>> GetAllSongs();
        Task<Song> GetSongById(Guid songId);
        Task<IEnumerable<Song>> GetArtistSongsById(Guid artistId);
        Task<IEnumerable<Song>> GetAlbumSongsById(Guid albumId);
        #endregion

        // TODO: Implement this somehow => Maybe create a model instead of dtos?
        // Task<Discography> GetDiscography(Guid artistId);
        // Task<Discography> GetDiscography(Artist artist); 
    }
}