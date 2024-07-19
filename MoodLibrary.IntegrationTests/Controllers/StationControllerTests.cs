using Microsoft.Extensions.Logging;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Services;
using Moq;

namespace MoodLibrary.UnitTests.Controllers
{
    public class StationControllerTests
    {
        private Mock<IStationService> mockStationService;
        private Mock<ILogger<StationController>> mockLogger;
        private StationController stationController;

        [SetUp]
        public void Setup()
        {
            mockStationService = new Mock<IStationService>();
            mockLogger = new Mock<ILogger<StationController>>();

            stationController = new StationController(mockStationService.Object, mockLogger.Object);
        }

        #region GetAll Tests
        #endregion

        #region GetStation Tests
        #endregion

        #region AddStation Tests
        #endregion

        #region AddStationSongs
        #endregion

        #region UpdateStation
        #endregion

        #region DeleteStation Tests
        #endregion
    }
}
