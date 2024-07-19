using Microsoft.Extensions.Logging;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Services;
using Moq;

namespace MoodLibrary.UnitTests.Controllers
{
    public class PlaylistControllerTests
    {
        private Mock<IPlaylistService> mockPlaylistService;
        private Mock<ILogger<PlaylistController>> mockLogger;
        private PlaylistController playlistController;

        [SetUp]
        public void Setup()
        {
            mockPlaylistService = new Mock<IPlaylistService>();
            mockLogger = new Mock<ILogger<PlaylistController>>();

            playlistController = new PlaylistController(mockPlaylistService.Object, mockLogger.Object);
        }

        #region GetAll Tests
        #endregion

        #region GetPlaylist Tests
        #endregion

        #region AddPlaylist Tests
        #endregion

        #region AddPlaylistSongs
        #endregion

        #region UpdatePlaylist
        #endregion

        #region DeletePlaylist Tests
        #endregion
    }
}
