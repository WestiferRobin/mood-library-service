using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("album")]
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
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var albums = await service.GetAll();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(Guid id)
        {
            var album = await service.GetAlbum(id);
            if (album == null) return NotFound($"Album not found for id: {id}");
            return Ok(album);
        }
        #endregion

        #region POST Methods
        [HttpPost]
        public async Task<IActionResult> AddAlbum([FromBody] AlbumDto album)
        {
            await service.AddAlbum(album);
            return Ok();
        }

        // TODO: Fix this crap
        // [HttpPost("/songs")]
        // public async Task<IActionResult> AddSongs([FromBody] List<SongDto> songs)
        // {
        //     await service.AddSongs(songs);
        //     return Ok();
        // }
        #endregion

        #region PUT Methods
        // TODO: Need to add update methods
        #endregion

        #region DELETE Methods
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(Guid id)
        {
            await service.DeleteAlbum(id);
            return Ok();
        }
        #endregion
    }
}