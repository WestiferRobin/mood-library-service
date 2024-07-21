using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("playlists")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService service;
        private readonly ILogger<PlaylistController> logger;

        public PlaylistController(IPlaylistService service, ILogger<PlaylistController> logger)
        {
            this.service = service;
            this.logger = logger;
        }

        #region GET Methods

        [HttpGet]
        public async Task<IActionResult> GetAllPlaylists()
        {
            try
            {
                var playlists = await service.GetAllPlaylists();
                return Ok(playlists);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all playlists");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaylist(Guid id)
        {
            try
            {
                var playlist = await service.GetPlaylist(id);
                if (playlist == null)
                {
                    return NotFound();
                }
                return Ok(playlist);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching playlist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region POST Methods

        [HttpPost]
        public async Task<IActionResult> AddPlaylist([FromBody] PlaylistDto playlistDto)
        {
            if (playlistDto == null)
            {
                return BadRequest("Playlist data is null");
            }

            try
            {
                await service.AddPlaylist(playlistDto);
                return CreatedAtAction(nameof(GetPlaylist), new { id = playlistDto.Id }, playlistDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding new playlist");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region PUT Methods

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlaylist(Guid id, [FromBody] PlaylistDto playlistDto)
        {
            if (playlistDto == null)
            {
                return BadRequest("Playlist data is invalid");
            }

            try
            {
                var existingPlaylist = await service.GetPlaylist(id);
                if (existingPlaylist == null)
                {
                    return NotFound();
                }

                await service.UpdatePlaylist(playlistDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating playlist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region DELETE Methods

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(Guid id)
        {
            try
            {
                var existingPlaylist = await service.GetPlaylist(id);
                if (existingPlaylist == null)
                {
                    return NotFound();
                }

                await service.DeletePlaylist(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error deleting playlist with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        #endregion
    }
}