using Microsoft.Extensions.Logging;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Services;
using Moq;

namespace MoodLibrary.UnitTests.Controllers
{
    public class AlbumControllerTests
    {
        private Mock<IAlbumService> mockAlbumService;
        private Mock<ILogger<AlbumController>> mockLogger;
        private AlbumController albumController;

        [SetUp]
        public void Setup()
        {
            mockAlbumService = new Mock<IAlbumService>();
            mockLogger = new Mock<ILogger<AlbumController>>();

            albumController = new AlbumController(mockAlbumService.Object, mockLogger.Object);
        }

        #region GetAll Tests
        #endregion

        #region GetAlbum Tests
        #endregion

        #region AddAlbum Tests
        #endregion

        #region AddAlbumSongs
        #endregion

        #region UpdateAlbum
        #endregion

        #region DeleteAlbum Tests
        #endregion
    }
}
