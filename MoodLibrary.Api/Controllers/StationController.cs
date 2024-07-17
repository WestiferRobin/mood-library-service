using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Services;

namespace MoodLibrary.Api.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("station")]
    public class StationController : ControllerBase
    {
        private readonly IStationService service;
        private readonly ILogger<StationController> logger;

        public StationController(IStationService service, ILogger<StationController> logger)
        {
            this.service = service;
            this.logger = logger;
        }
    }
}