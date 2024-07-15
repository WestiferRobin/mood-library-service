using MoodLibraryApi.Models;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IArtistRepository artistRepository;
        private readonly IAlbumRepository albumRepository;
        private readonly ISongRepository songRepository;

        public LibraryService(IArtistRepository artistRepository, IAlbumRepository albumRepository, ISongRepository songRepository)
        {
            this.artistRepository = artistRepository;
            this.albumRepository = albumRepository;
            this.songRepository = songRepository;
        }

        #region Artist Methods
        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await artistRepository.GetAll();
        }

        public async Task<Artist> GetArtistById(Guid artistId)
        {
            return await artistRepository.GetById(artistId);
        }
        #endregion

        #region Album Methods
        public async Task<IEnumerable<Album>> GetAllAlbums()
        {
            return await albumRepository.GetAll();
        }

        public async Task<IEnumerable<Album>> GetArtistAlbumsById(Guid artistId)
        {
            var albums = await GetAllAlbums();
            return albums.Where(album => album.ArtistId == artistId).ToList();
        }

        public async Task<Album> GetAlbumById(Guid albumId)
        {
            return await albumRepository.GetById(albumId);
        }
        #endregion

        #region  Song Methods
        public async Task<IEnumerable<Song>> GetAllSongs()
        {
            return await songRepository.GetAll();
        }
        public async Task<Song> GetSongById(Guid songId)
        {
            return await songRepository.GetById(songId);
        }
        public async Task<IEnumerable<Song>> GetArtistSongsById(Guid artistId)
        {
            var allSongs = await GetAllSongs();
            return allSongs.Where(song => song.ArtistId == artistId);
        }
        public async Task<IEnumerable<Song>> GetAlbumSongsById(Guid albumId)
        {
            var allSongs = await GetAllSongs();
            return allSongs.Where(song => song.AlbumId == albumId);
        }
        #endregion

    }
}