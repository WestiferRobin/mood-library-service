//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using MoodLibrary.Api.Controllers;
//using MoodLibrary.Api.Dtos;
//using MoodLibrary.Api.Services;
//using Moq;

//namespace MoodLibrary.UnitTests.Controllers
//{
//    [TestFixture]
//    public class ArtistControllerTests
//    {
//        private Mock<IArtistService> mockArtistService;
//        private Mock<ILogger<ArtistController>> mockLogger;
//        private ArtistController artistController;

//        [SetUp]
//        public void Setup()
//        {
//            mockArtistService = new Mock<IArtistService>();
//            mockLogger = new Mock<ILogger<ArtistController>>();

//            artistController = new ArtistController(mockArtistService.Object, mockLogger.Object);
//        }

//        #region GetAll Tests

//        [Test]
//        public async Task GetAll_ReturnsOk_WithItemsFoundAll()
//        {
//            var expectedResults = new List<ArtistDto>
//            {
//                new()
//                {
//                    Name = "Artist 1",
//                    Genre = "Unknown"
//                }
//            };

//            mockArtistService.Setup(s => s.GetAll()).ReturnsAsync(expectedResults);

//            var result = await artistController.GetAll();

//            var okResult = result.Result as OkObjectResult;
//            Assert.IsNotNull(okResult);
//            var actualResults = okResult.Value as IEnumerable<ArtistDto>;
//            Assert.IsNotNull(actualResults);
//            Assert.IsTrue(actualResults.Any());
//        }

//        [Test]
//        public async Task GetAll_ReturnsNotFound_WithNoItemsFound()
//        {
//            var result = await artistController.GetAll();

//            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
//            var notFoundResult = result.Result as NotFoundObjectResult;
//            Assert.AreEqual("No Artists were found", notFoundResult.Value);
//        }

//        #endregion

//        #region GetArtist Tests
//        #endregion

//        #region GetDiscography Tests
//        #endregion

//        #region AddArtist Tests
//        #endregion

//        #region AddDiscography Tests
//        #endregion

//        #region UpdateArtists Tests
//        #endregion

//        #region DeleteArtist Tests
//        #endregion
//    }
//}
