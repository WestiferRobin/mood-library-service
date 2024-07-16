using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibraryApi.Services;

namespace MoodLibraryApi.Controllers
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
            return Ok("TODO");
        }

        [HttpGet("artists")]
        public async Task<ActionResult> GetAllArtists()
        {
            return Ok("Get all artists");
        }

        [HttpGet("albums")]
        public async Task<ActionResult> GetAllAlbums()
        {
            return Ok("Get all albums");
        }

        [HttpGet("playlists")]
        public async Task<ActionResult> GetAllPlaylists()
        {
            return Ok("Get all playlists");
        }

        [HttpGet("stations")]
        public async Task<ActionResult> GetAllStations()
        {
            return Ok("Get all stations");
        }

        [HttpGet("songs")]
        public async Task<ActionResult> GetAllSongs()
        {
            return Ok("Get all songs");
        }
    }
}