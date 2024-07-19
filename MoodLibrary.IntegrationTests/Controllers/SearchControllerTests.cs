using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Services;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Dtos.Responses;

namespace MoodLibrary.UnitTests.Controllers
{
    // TODO: Do loggers and try catches tests after doing service, repository, and model tests
    [TestFixture]
    public class SearchControllerTests
    {
        private Mock<ISearchService> mockSearchService;
        private Mock<ILogger<SearchController>> mockLogger;
        private SearchController searchController;
        private Dictionary<string, SearchItemDto> testData;

        [SetUp]
        public void Setup()
        {
            // Initialize mocks and the controller before each test
            mockSearchService = new Mock<ISearchService>();
            mockLogger = new Mock<ILogger<SearchController>>();

            // Create an instance of the controller with mocked dependencies
            searchController = new SearchController(mockSearchService.Object, mockLogger.Object);

            testData = new()
            {
                { "Artist", new SearchItemDto() {
                    Id = new Guid(),
                    Name = "Artist 1"
                }},
                { "Album", new SearchItemDto() {
                    Id = new Guid(),
                    Name = "Album 1"
                }},
                { "Playlist", new SearchItemDto() {
                    Id = new Guid(),
                    Name = "Playlist 1"
                }},
                { "Station", new SearchItemDto() {
                    Id = new Guid(),
                    Name = "Station 1"
                }},
                { "Song", new SearchItemDto() {
                    Id = new Guid(),
                    Name = "Song 1"
                }}
            };
        }

        #region GetAll Tests

        [Test]
        public async Task GetAll_ReturnsOk_WithItemsFound()
        {
            var expectedResults = new SearchResponseDto()
            {
                Artists = [testData["Artist"]],
                Albums = [testData["Album"]],
                Playlists = [testData["Playlist"]],
                Stations = [testData["Station"]],
                Songs = [testData["Song"]]
            };

            mockSearchService.Setup(s => s.GetAllItems()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAll();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as SearchResponseDto;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Artists.Count == 1);
            Assert.IsTrue(actualResults.Albums.Count == 1);
            Assert.IsTrue(actualResults.Playlists.Count == 1);
            Assert.IsTrue(actualResults.Stations.Count == 1);
            Assert.IsTrue(actualResults.Songs.Count == 1);
        }

        [Test]
        public async Task GetAll_ReturnsNotFound_WithNoItemsFound()
        {
            var result = await searchController.GetAll();
            
            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No items were found", notFoundResult.Value);
        }

        #endregion

        #region GetAllArtists Tests

        [Test]
        public async Task GetAllArtists_ReturnsOk_WithArtistsFound()
        {
            var expectedResults = new List<SearchItemDto>() { testData["Artist"] };

            mockSearchService.Setup(s => s.GetAllArtists()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAllArtists();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as IEnumerable<SearchItemDto>;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Any());
        }

        [Test]
        public async Task GetAllArtists_ReturnsNotFound_WithNoArtistsFound()
        {
            var result = await searchController.GetAllArtists();

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No Artists found in service", notFoundResult.Value);
        }

        #endregion

        #region GetAllAlbums Tests

        [Test]
        public async Task GetAllAlbums_ReturnsOk_WithAlbumsFound()
        {
            var expectedResults = new List<SearchItemDto>() { testData["Album"] };

            mockSearchService.Setup(s => s.GetAllAlbums()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAllAlbums();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as IEnumerable<SearchItemDto>;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Any());
        }

        [Test]
        public async Task GetAllAlbums_ReturnsNotFound_WithNoAlbumsFound()
        {
            var result = await searchController.GetAllAlbums();

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No Albums found in service", notFoundResult.Value);
        }

        #endregion

        #region GetAllPlaylists Tests

        [Test]
        public async Task GetAllPlaylists_ReturnsOk_WithPlaylistsFound()
        {
            var expectedResults = new List<SearchItemDto>() { testData["Playlist"] };

            mockSearchService.Setup(s => s.GetAllPlaylists()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAllPlaylists();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as IEnumerable<SearchItemDto>;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Any());
        }

        [Test]
        public async Task GetAllPlaylists_ReturnsNotFound_WithNoPlaylistsFound()
        {
            var result = await searchController.GetAllPlaylists();

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No Playlists found in service", notFoundResult.Value);
        }

        #endregion

        #region GetAllStations Tests

        [Test]
        public async Task GetAllStations_ReturnsOk_WithStationsFound()
        {
            var expectedResults = new List<SearchItemDto>() { testData["Station"] };

            mockSearchService.Setup(s => s.GetAllStations()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAllStations();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as IEnumerable<SearchItemDto>;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Any());
        }

        [Test]
        public async Task GetAllStations_ReturnsNotFound_WithNoStationsFound()
        {
            var result = await searchController.GetAllStations();

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No Stations found in service", notFoundResult.Value);
        }

        #endregion

        #region GetAllSongs Tests

        [Test]
        public async Task GetAllSongs_ReturnsOk_WithSongsFound()
        {
            var expectedResults = new List<SearchItemDto>() { testData["Song"] };

            mockSearchService.Setup(s => s.GetAllSongs()).ReturnsAsync(expectedResults);

            var result = await searchController.GetAllSongs();

            var okResult = result.Result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as IEnumerable<SearchItemDto>;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Any());
        }

        [Test]
        public async Task GetAllSongs_ReturnsNotFound_WithNoSongsFound()
        {
            var result = await searchController.GetAllSongs();

            Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
            var notFoundResult = result.Result as NotFoundObjectResult;
            Assert.AreEqual("No Songs found in service", notFoundResult.Value);
        }

        #endregion
    }
}
