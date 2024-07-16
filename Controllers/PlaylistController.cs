using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibraryApi.Services;

namespace MoodLibraryApi.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("playlist")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService service;
        private readonly ILogger<PlaylistController> logger;

        public PlaylistController(IPlaylistService service, ILogger<PlaylistController> logger)
        {
            this.service = service;
            this.logger = logger;
        }
    }
}