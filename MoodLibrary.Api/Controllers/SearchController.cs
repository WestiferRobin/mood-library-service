using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Dtos.Responses;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("search")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService service;
        private readonly ILogger<SearchController> logger;

        public SearchController(ISearchService service, ILogger<SearchController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<SearchResponseDto>> GetAll()
        {
            var results = await service.GetAllItems();
            if (results == null) return NotFound("No items we're found");
            return Ok(results);
        }

        [HttpGet("artists")]
        public async Task<ActionResult<IEnumerable<SearchItemDto>>> GetAllArtists()
        {
            var allArtists = await service.GetAllArtists();
            if (!allArtists.Any()) return NotFound("No Artists found in service");
            return Ok(allArtists);
        }

        [HttpGet("albums")]
        public async Task<ActionResult> GetAllAlbums()
        {
            var allAlbums = await service.GetAllAlbums();
            if (!allAlbums.Any()) return NotFound("No Albums found in service");
            return Ok(allAlbums);
        }

        [HttpGet("playlists")]
        public async Task<ActionResult> GetAllPlaylists()
        {
            var allPlaylists = await service.GetAllPlaylists();
            if (!allPlaylists.Any()) return NotFound("No Playlists found in service");
            return Ok(allPlaylists);
        }

        [HttpGet("stations")]
        public async Task<ActionResult> GetAllStations()
        {
            var allStations = await service.GetAllStations();
            if (!allStations.Any()) return NotFound("No Stations found in service");
            return Ok(allStations);
        }

        [HttpGet("songs")]
        public async Task<ActionResult> GetAllSongs()
        {
            var allSongs = await service.GetAllSongs();
            if (!allSongs.Any()) return NotFound("No Songs found in service");
            return Ok(allSongs);
        }
    }
}