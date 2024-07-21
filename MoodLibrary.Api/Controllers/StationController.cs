using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("stations")]
    public class StationController : ControllerBase
    {
        private readonly IStationService service;
        private readonly ILogger<StationController> logger;

        public StationController(IStationService service, ILogger<StationController> logger)
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