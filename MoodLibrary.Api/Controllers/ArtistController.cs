using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("artists")]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService service;
        private readonly ILogger<ArtistController> logger;

        public ArtistController(IArtistService service, ILogger<ArtistController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        #region GET Methods
        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            try
            {
                var artists = await service.GetAllArtists();
                return Ok(artists);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all artists");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetArtist(Guid id)
        {
            try
            {
                var artist = await service.GetArtist(id);
                if (artist == null)
                {
                    return NotFound();
                }
                return Ok(artist);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching artist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        #region POST Methods
        #endregion

        #region PUT Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}