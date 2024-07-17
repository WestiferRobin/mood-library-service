using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.AspNetCore.Mvc;
using MoodLibrary.Api.Services;
using MoodLibrary.Api.Controllers;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Dtos.Responses;

namespace MoodLibrary.UnitTests.Controllers
{
    // TODO: Need to fix this stuff on mac. look into why intellasense isn't working
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

        [Test]
        public async Task GetAll_ReturnsOkWithItems()
        {
            var debugId = new Guid("dddddddd-dddd-dddd-dddd-dddddddddddd");
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

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResults = okResult.Value as SearchResponseDto;
            Assert.IsNotNull(actualResults);
            Assert.IsTrue(actualResults.Artists.Count == 1);
            Assert.IsTrue(actualResults.Albums.Count == 1);
            Assert.IsTrue(actualResults.Playlists.Count == 1);
            Assert.IsTrue(actualResults.Stations.Count == 1);
            Assert.IsTrue(actualResults.Songs.Count == 1);
        }

    }
}
