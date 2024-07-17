using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetAll()
        {
            var results = await service.GetAllItems();
            return Ok(results);
        }

        [HttpGet("artists")]
        public async Task<ActionResult> GetAllArtists()
        {
            var allArtists = await service.GetAllArtists();
            return Ok(allArtists);
        }

        [HttpGet("albums")]
        public async Task<ActionResult> GetAllAlbums()
        {
            var allAlbums = await service.GetAllAlbums();
            return Ok(allAlbums);
        }

        [HttpGet("playlists")]
        public async Task<ActionResult> GetAllPlaylists()
        {
            var allPlaylists = await service.GetAllPlaylists();
            return Ok(allPlaylists);
        }

        [HttpGet("stations")]
        public async Task<ActionResult> GetAllStations()
        {
            var allStations = await service.GetAllStations();
            return Ok(allStations);
        }

        [HttpGet("songs")]
        public async Task<ActionResult> GetAllSongs()
        {
            var allSongs = await service.GetAllSongs();
            return Ok(allSongs);
        }
    }
}