using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Dtos;
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

        [HttpGet]
        public async Task<IActionResult> GetAllStations()
        {
            try
            {
                var stations = await service.GetAllStations();
                return Ok(stations);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all stations");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStation(Guid id)
        {
            try
            {
                var station = await service.GetStation(id);
                if (station == null)
                {
                    return NotFound();
                }
                return Ok(station);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching station with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region POST Methods

        [HttpPost]
        public async Task<IActionResult> AddStation([FromBody] StationDto stationDto)
        {
            if (stationDto == null)
            {
                return BadRequest("Station data is null");
            }

            try
            {
                await service.AddStation(stationDto);
                return CreatedAtAction(nameof(GetStation), new { id = stationDto.Id }, stationDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding new station");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region PUT Methods

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStation(Guid id, [FromBody] StationDto stationDto)
        {
            if (stationDto == null)
            {
                return BadRequest("Station data is invalid");
            }

            try
            {
                var existingStation = await service.GetStation(id);
                if (existingStation == null)
                {
                    return NotFound();
                }

                await service.UpdateStation(stationDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating station with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }

        #endregion

        #region DELETE Methods

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStation(Guid id)
        {
            try
            {
                var existingStation = await service.GetStation(id);
                if (existingStation == null)
                {
                    return NotFound();
                }

                await service.DeleteStation(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error deleting station with id {id}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        #endregion
    }
}