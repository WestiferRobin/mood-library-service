using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("albums")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService service;
        private readonly ILogger<AlbumController> logger;

        public AlbumController(IAlbumService service, ILogger<AlbumController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        #region GET Methods

        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            try
            {
                var albums = await service.GetAllAlbums();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all albums");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            try
            {
                var album = await service.GetAlbum(id);
                if (album == null)
                {
                    return NotFound();
                }
                return Ok(album);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching album with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region POST Methods

        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumDto albumDto)
        {
            if (albumDto == null)
            {
                return BadRequest("Album data is null");
            }

            try
            {
                await service.AddAlbum(albumDto);
                return CreatedAtAction(nameof(GetAlbum), new { id = albumDto.Id }, albumDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding new album");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region PUT Methods

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(Guid id, [FromBody] AlbumDto albumDto)
        {
            if (albumDto == null)
            {
                return BadRequest("Album data is invalid");
            }

            try
            {
                var existingAlbum = await service.GetAlbum(id);
                if (existingAlbum == null)
                {
                    return NotFound();
                }

                await service.UpdateAlbum(albumDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating album with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region DELETE Methods

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            try
            {
                var existingAlbum = await service.GetAlbum(id);
                if (existingAlbum == null)
                {
                    return NotFound();
                }

                await service.DeleteAlbum(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error deleting album with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        #endregion
    }
}