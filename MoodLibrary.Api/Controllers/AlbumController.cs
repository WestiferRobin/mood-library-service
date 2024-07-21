using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        #endregion

        #region POST Methods
        #endregion

        #region PUT Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}