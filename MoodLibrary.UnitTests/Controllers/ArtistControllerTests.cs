using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Services;
using Moq;

namespace MoodLibrary.UnitTests.Controllers
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private Mock<IArtistService> mockArtistService;
        private Mock<ILogger<ArtistController>> mockLogger;
        private ArtistController artistController;

        [SetUp]
        public void Setup()
        {
            mockArtistService = new Mock<IArtistService>();
            mockLogger = new Mock<ILogger<ArtistController>>();

            artistController = new ArtistController(mockArtistService.Object, mockLogger.Object);
        }

        #region GET Tests
        #endregion

        #region POST Tests
        #endregion

        #region PUT Tests
        #endregion

        #region DELETE Tests
        #endregion
    }
}
