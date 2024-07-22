using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Exceptions;
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
            catch (NoArtistsException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all artists");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(Guid id)
        {
            try
            {
                var artist = await service.GetArtist(id);
                return Ok(artist);
            }
            catch (NoArtistsException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching artist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region POST Methods

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistDto artistDto)
        {
            try
            {
                await service.AddArtist(artistDto);
                return NoContent();
            }
            catch (InvalidParamException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding new artist");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region PUT Methods

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(Guid id, [FromBody] ArtistDto artistDto)
        {
            try
            {
                await service.UpdateArtist(id, artistDto);
                return NoContent();
            }
            catch (NoArtistsException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (InvalidParamException ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating artist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region DELETE Methods

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(Guid id)
        {
            try
            {
                await service.DeleteArtist(id);
                return NoContent();
            }
            catch (NoArtistsException ex)
            {
                logger.LogError(ex, ex.Message);
                return NotFound();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error deleting artist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        #endregion
    }
}