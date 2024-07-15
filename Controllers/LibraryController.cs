
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibraryApi.Dtos;
using MoodLibraryApi.Dtos.Requests;
using MoodLibraryApi.Dtos.Responses;
using MoodLibraryApi.Services;

namespace MoodLibraryApi.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("library")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService libraryService;
        private readonly ILogger<LibraryController> logger;
        // private readonly IMapper mapper;

        public LibraryController(ILibraryService libraryService, ILogger<LibraryController> logger)
        {
            this.libraryService = libraryService;
            this.logger = logger;
            // this.mapper = mapper;
        }

        #region Artist Endpoints

        [HttpGet("artists")]
        public async Task<IActionResult> GetArtists()
        {
            var artists = await libraryService.GetAllArtists();
            if (!artists.Any()) return NotFound();

            var artistDtos = new List<ArtistDto>();
            foreach (var artist in artists)
            {
                var artistDto = new ArtistDto()
                {
                    Name = artist.Name
                };
                artistDtos.Add(artistDto);
            }

            return Ok(artistDtos);
        }

        [HttpPost("artist")] // This is for the Artist's View in React
        public async Task<IActionResult> GetArtist([FromBody] ArtistRequestDto request)
        {
            var artistId = request.ArtistId;

            var artist = await libraryService.GetArtistById(artistId);
            if (artist == null) return NotFound();

            var artistAlbums = await libraryService.GetArtistAlbumsById(artistId);
            if (!artistAlbums.Any()) return NotFound();
            var albums = new List<AlbumNameDto>();
            foreach (var album in artistAlbums)
            {
                var albumDto = new AlbumNameDto() {
                    Name = album.Name
                };
                albums.Add(albumDto);
            }

            var songs = await libraryService.GetArtistSongsById(artistId);
            if (!songs.Any()) return NotFound();
            var topTen = new List<SongDto>();
            for (int index = 0; index < 10; index++)
            {
                var song = songs.ElementAt(index);
                var songDto = new SongDto()
                {
                    Name = song.Name,
                    Duration = song.Duration
                };
                topTen.Add(songDto);
            }

            var response = new ArtistResponseDto() {
                Name = artist.Name,
                TopTen = topTen,
                Albums = albums
            };

            return Ok(response);
        }

        [HttpPost("artist/discography")] // This is for the Dicography's View in React
        public async Task<IActionResult> GetDiscography([FromBody] ArtistRequestDto request)
        {
            var artistId = request.ArtistId;
            var artist = await libraryService.GetArtistById(artistId);
            if (artist == null) return NotFound();

            var albums = await libraryService.GetArtistAlbumsById(artistId);
            if (!albums.Any()) return NotFound();
            
            var albumDtos = new List<AlbumDto>();
            foreach (var album in albums)
            {
                var albumId = album.Id;

                var songs = await libraryService.GetAlbumSongsById(albumId);
                var songDtos = new List<SongDto>();
                foreach (var song in songs)
                {
                    var songDto = new SongDto()
                    {
                        Name = song.Name,
                        Duration = song.Duration
                    };
                    songDtos.Add(songDto);
                }

                var albumDto = new AlbumDto()
                {
                    Name = album.Name,
                    Songs = songDtos
                };
                albumDtos.Add(albumDto);
            }

            var response = new DiscographyResponseDto()
            {
                ArtistName = artist.Name,
                Discography = albumDtos
            };
            return Ok(response);
        }
        #endregion

        #region Album Endpoints
        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbums()
        {
            var albums = await libraryService.GetAllAlbums();
            if (!albums.Any()) return NotFound();

            var albumDtos = new List<AlbumNameDto>();
            foreach (var album in albums)
            {
                var albumDto = new AlbumNameDto()
                {
                    Name = album.Name
                };
                albumDtos.Add(albumDto);
            }

            return Ok(albumDtos);
        }

        [HttpPost("album")]
        public async Task<IActionResult> GetAlbum([FromBody] AlbumRequestDto request)
        {
            var albumId = request.AlbumId;

            var album = await libraryService.GetAlbumById(albumId);
            if (album == null) return NotFound();

            var artist = await libraryService.GetArtistById(album.ArtistId);
            if (artist == null) return NotFound();

            var songs = await libraryService.GetAlbumSongsById(albumId);
            if (!songs.Any()) return NotFound();

            var songDtos = new List<SongDto>();
            foreach (var song in songs)
            {
                var songDto = new SongDto()
                {
                    Name = song.Name,
                    Duration = song.Duration
                };
                songDtos.Add(songDto);
            }

            var response = new AlbumResponseDto()
            {
                AlbumName = album.Name,
                ArtistName = artist.Name,
                Songs = songDtos
            };

            return Ok(response);
        }
        #endregion

        #region TODO Playlist Endpoints
        // Get all playlists
        // Get a specific playlist
        #endregion

        #region  TODO Station Endpoints
        // Get all stations
        // Get a specific station
        #endregion
    }
}



