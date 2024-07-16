using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibraryApi.Dtos;
using MoodLibraryApi.Services;

namespace MoodLibraryApi.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("artist")]
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
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var artists = await service.GetAll();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(Guid id)
        {
            var artist = await service.GetArtist(id);
            if (artist == null) return NotFound($"Artist not found for id: {id}");
            return Ok(artist);
        }

        [HttpGet("{id}/discography")]
        public async Task<IActionResult> GetDiscography(Guid id)
        {
            var discography = await service.GetDiscography(id);
            return Ok(discography);
        }
        #endregion

        #region POST Methods
        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistDto artist)
        {
            await service.AddArtist(artist);
            return Ok();
        }

        [HttpPost("/discography")]
        public async Task<IActionResult> AddDiscography([FromBody] DiscographyDto discography)
        {
            await service.AddDiscography(discography);
            return Ok();
        }
        #endregion

        #region PUT Methods
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(Guid id, [FromBody] ArtistDto artist)
        {
            await service.UpdateArtist(id, artist);
            return Ok();
        }
        #endregion

        #region DELETE Methods
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(Guid id)
        {
            await service.DeleteArtist(id);
            return Ok();
        }
        #endregion
    }
}