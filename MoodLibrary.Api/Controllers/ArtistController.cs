using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
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

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistDto artistDto)
        {
            if (artistDto == null)
            {
                return BadRequest("Artist data is null");
            }

            try
            {
                await service.AddArtist(artistDto);
                return CreatedAtAction(nameof(GetArtist), new { id = artistDto.Id }, artistDto);
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
            if (artistDto == null)
            {
                return BadRequest("Artist data is invalid");
            }

            try
            {
                var existingArtist = await service.GetArtist(id);
                if (existingArtist == null)
                {
                    return NotFound();
                }

                await service.UpdateArtist(artistDto);
                return NoContent();
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
                var existingArtist = await service.GetArtist(id);
                if (existingArtist == null)
                {
                    return NotFound();
                }

                await service.DeleteArtist(id);
                return NoContent();
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