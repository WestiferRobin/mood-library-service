using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Exceptions;
using MoodLibrary.Api.Services;

namespace MoodLibrary.UnitTests.Controllers
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private Mock<IArtistService> mockService;
        private Mock<ILogger<ArtistController>> mockLogger;
        private ArtistController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IArtistService>();
            mockLogger = new Mock<ILogger<ArtistController>>();
            controller = new ArtistController(mockService.Object, mockLogger.Object);
        }

        #region GET Methods

        [Test]
        public async Task GetAllArtists_ReturnsOkResult_WithListOfArtists()
        {
            // Arrange
            var artists = new List<ArtistDto> { new ArtistDto { Name = "Artist1", Genre = "Unknown" } };
            mockService.Setup(s => s.GetAllArtists()).ReturnsAsync(artists);

            // Act
            var result = await controller.GetAllArtists();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(artists, okResult.Value);
        }

        [Test]
        public async Task GetAllArtists_ReturnsNotFound_WhenNoArtistsExist()
        {
            // Arrange
            mockService.Setup(s => s.GetAllArtists()).ThrowsAsync(new NoArtistsException());

            // Act
            var result = await controller.GetAllArtists();

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task GetArtist_ReturnsOkResult_WithArtist()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var artist = new ArtistDto { Name = "Artist1", Genre = "Unknown" };
            mockService.Setup(s => s.GetArtist(artistId)).ReturnsAsync(artist);

            // Act
            var result = await controller.GetArtist(artistId);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(artist, okResult.Value);
        }

        [Test]
        public async Task GetArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.GetArtist(artistId)).ThrowsAsync(new NoArtistsException());

            // Act
            var result = await controller.GetArtist(artistId);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        #endregion

        #region POST Methods

        [Test]
        public async Task AddArtist_ReturnsNoContent()
        {
            // Arrange
            var artistDto = new ArtistDto { Name = "New Artist" };

            // Act
            var result = await controller.AddArtist(artistDto);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(204, noContentResult.StatusCode);
        }

        [Test]
        public async Task AddArtist_ReturnsBadRequest_WhenInvalidParamExceptionThrown()
        {
            // Arrange
            var artistDto = new ArtistDto { Name = "New Artist" };
            mockService.Setup(s => s.AddArtist(artistDto)).ThrowsAsync(new InvalidParamException("Invalid artist"));

            // Act
            var result = await controller.AddArtist(artistDto);

            // Assert
            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid artist", badRequestResult.Value);
        }

        #endregion

        #region PUT Methods

        [Test]
        public async Task UpdateArtist_ReturnsNoContent()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var artistDto = new ArtistDto { Name = "Updated Artist" };

            // Act
            var result = await controller.UpdateArtist(artistId, artistDto);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(204, noContentResult.StatusCode);
        }

        [Test]
        public async Task UpdateArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var artistDto = new ArtistDto { Name = "Updated Artist" };
            mockService.Setup(s => s.UpdateArtist(artistId, artistDto)).ThrowsAsync(new NoArtistsException());

            // Act
            var result = await controller.UpdateArtist(artistId, artistDto);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        #endregion

        #region DELETE Methods

        [Test]
        public async Task DeleteArtist_ReturnsNoContent()
        {
            // Arrange
            var artistId = Guid.NewGuid();

            // Act
            var result = await controller.DeleteArtist(artistId);

            // Assert
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
            Assert.AreEqual(204, noContentResult.StatusCode);
        }

        [Test]
        public async Task DeleteArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.DeleteArtist(artistId)).ThrowsAsync(new NoArtistsException());

            // Act
            var result = await controller.DeleteArtist(artistId);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        #endregion
    }
}
