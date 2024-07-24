using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Exceptions;
using MoodLibrary.Api.Services;
using MoodLibrary.UnitTests.Utils;

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
            var artists = TestData.GetArtistDtos();
            mockService.Setup(s => s.GetAllArtists()).ReturnsAsync(artists);

            var result = await controller.GetAllArtists();

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(artists, okResult.Value);
        }

        [Test]
        public async Task GetAllArtists_ReturnsNotFound_WhenNoArtistsExist()
        {
            mockService.Setup(s => s.GetAllArtists()).ThrowsAsync(new NoArtistsException());

            var result = await controller.GetAllArtists();

            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task GetAllArtists_ReturnsInternalError_WhenInternalServerError()
        {
            mockService.Setup(s => s.GetAllArtists()).ThrowsAsync(new Exception());

            var result = await controller.GetAllArtists();

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(500, errorResult.StatusCode);
        }

        [Test]
        public async Task GetArtist_ReturnsOkResult_WithArtist()
        {
            var artistId = Guid.NewGuid();
            var artists = TestData.GetArtistDtos();
            var artist = artists[0];
            mockService.Setup(s => s.GetArtist(artistId)).ReturnsAsync(artist);

            var result = await controller.GetArtist(artistId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(artist, okResult.Value);
        }

        [Test]
        public async Task GetArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.GetArtist(artistId)).ThrowsAsync(new NoArtistsException());

            var result = await controller.GetArtist(artistId);

            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task GetArtist_ReturnsInternalError_WhenInternalServerError()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.GetArtist(artistId)).ThrowsAsync(new Exception());

            var result = await controller.GetArtist(artistId);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(500, errorResult.StatusCode);
        }

        #endregion

        #region POST Methods

        [Test]
        public async Task AddArtist_ReturnsOkResult()
        {
            var artists = TestData.GetArtistDtos();
            var artistDto = artists[0];
            mockService.Setup(s => s.AddArtist(artistDto)).Returns(Task.CompletedTask);

            var result = await controller.AddArtist(artistDto);

            var okResult = result as OkResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            mockService.Verify(s => s.AddArtist(artistDto), Times.Once);
        }

        [Test]
        public async Task AddArtist_ReturnsBadRequest_WhenInvalidParamExceptionThrown()
        {
            mockService.Setup(s => s.AddArtist(null)).ThrowsAsync(new InvalidParamException());

            var result = await controller.AddArtist(null);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid parameter.", badRequestResult.Value);
        }

        [Test]
        public async Task AddArtist_ReturnsInternalError_WhenInternalServerError()
        {
            var artists = TestData.GetArtistDtos();
            var artistDto = artists[0];
            mockService.Setup(s => s.AddArtist(artistDto)).ThrowsAsync(new Exception());

            var result = await controller.AddArtist(artistDto);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(500, errorResult.StatusCode);
        }

        #endregion

        #region PUT Methods

        [Test]
        public async Task UpdateArtist_ReturnsOkResult()
        {
            var artistId = Guid.NewGuid();
            var artists = TestData.GetArtistDtos();
            var artistDto = artists[0];
            mockService.Setup(s => s.UpdateArtist(artistId, artistDto)).Returns(Task.CompletedTask);

            var result = await controller.UpdateArtist(artistId, artistDto);

            var okResult = result as OkResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            mockService.Verify(s => s.UpdateArtist(artistId, artistDto), Times.Once);
        }

        [Test]
        public async Task UpdateArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            var artistId = Guid.NewGuid();
            var artists = TestData.GetArtistDtos();
            var artistDto = artists[0];
            mockService.Setup(s => s.UpdateArtist(artistId, artistDto)).ThrowsAsync(new NoArtistsException());

            var result = await controller.UpdateArtist(artistId, artistDto);

            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task UpdateArtist_ReturnsBadRequest_WhenInvalidParamExceptionThrown()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.UpdateArtist(artistId, null)).ThrowsAsync(new InvalidParamException());

            var result = await controller.UpdateArtist(artistId, null);

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
            Assert.AreEqual("Invalid parameter.", badRequestResult.Value);
        }

        [Test]
        public async Task UpdateArtist_ReturnsInternalError_WhenInternalServerError()
        {
            var artistId = Guid.NewGuid();
            var artists = TestData.GetArtistDtos();
            var artistDto = artists[0];
            mockService.Setup(s => s.UpdateArtist(artistId, artistDto)).ThrowsAsync(new Exception());

            var result = await controller.UpdateArtist(artistId, artistDto);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(500, errorResult.StatusCode);
        }

        #endregion

        #region DELETE Methods

        [Test]
        public async Task DeleteArtist_ReturnsOkResult()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.DeleteArtist(artistId)).Returns(Task.CompletedTask);

            var result = await controller.DeleteArtist(artistId);

            var okResult = result as OkResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            mockService.Verify(s => s.DeleteArtist(artistId), Times.Once);
        }

        [Test]
        public async Task DeleteArtist_ReturnsNotFound_WhenArtistDoesNotExist()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.DeleteArtist(artistId)).ThrowsAsync(new NoArtistsException());

            var result = await controller.DeleteArtist(artistId);

            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }

        [Test]
        public async Task DeleteArtist_ReturnsInternalError_WhenInternalServerError()
        {
            var artistId = Guid.NewGuid();
            mockService.Setup(s => s.DeleteArtist(artistId)).ThrowsAsync(new Exception());

            var result = await controller.DeleteArtist(artistId);

            var errorResult = result as ObjectResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(500, errorResult.StatusCode);
        }

        #endregion

    }
}
