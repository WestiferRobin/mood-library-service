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
        #endregion

        #region POST Methods
        #endregion

        #region PUT Methods
        #endregion

        #region DELETE Methods
        #endregion
    }
}