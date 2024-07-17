using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        [SetUp]
        public void Setup()
        {
            // Initialize mocks and the controller before each test
            mockSearchService = new Mock<ISearchService>();
            mockLogger = new Mock<ILogger<SearchController>>();

            // Create an instance of the controller with mocked dependencies
            searchController = new SearchController(mockSearchService.Object, mockLogger.Object);
        }

        //[Test]
        //public async Task GetAll_ReturnsOkWithItems()
        //{
        //    // Arrange
        //    var expectedResults = new List<SearchResponseDto> { new SearchResponseDto { Id = 1, Name = "Sample Item" } };
        //    mockSearchService.Setup(service => service.GetAllItems()).ReturnsAsync(expectedResults);

        //    // Act
        //    var result = await searchController.GetAll();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualResults = Assert.IsAssignableFrom<List<SearchResponseDto>>(okResult.Value);
        //    Assert.AreEqual(expectedResults.Count, actualResults.Count);
        //    Assert.AreEqual(expectedResults[0].Id, actualResults[0].Id);
        //    Assert.AreEqual(expectedResults[0].Name, actualResults[0].Name);
        //}

        //[Test]
        //public async Task GetAllArtists_ReturnsOkWithArtists()
        //{
        //    // Arrange
        //    var expectedArtists = new List<ArtistDto> { new ArtistDto { Id = 1, Name = "Artist 1" }, new ArtistDto { Id = 2, Name = "Artist 2" } };
        //    mockSearchService.Setup(service => service.GetAllArtists()).ReturnsAsync(expectedArtists);

        //    // Act
        //    var result = await searchController.GetAllArtists();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualArtists = Assert.IsAssignableFrom<List<ArtistDto>>(okResult.Value);
        //    Assert.AreEqual(expectedArtists.Count, actualArtists.Count);
        //    Assert.AreEqual(expectedArtists[0].Id, actualArtists[0].Id);
        //    Assert.AreEqual(expectedArtists[0].Name, actualArtists[0].Name);
        //}

        //[Test]
        //public async Task GetAllAlbums_ReturnsOkWithAlbums()
        //{
        //    // Arrange
        //    var expectedAlbums = new List<AlbumDto> { new AlbumDto { Id = 1, Title = "Album 1" }, new AlbumDto { Id = 2, Title = "Album 2" } };
        //    mockSearchService.Setup(service => service.GetAllAlbums()).ReturnsAsync(expectedAlbums);

        //    // Act
        //    var result = await searchController.GetAllAlbums();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualAlbums = Assert.IsAssignableFrom<List<AlbumDto>>(okResult.Value);
        //    Assert.AreEqual(expectedAlbums.Count, actualAlbums.Count);
        //    Assert.AreEqual(expectedAlbums[0].Id, actualAlbums[0].Id);
        //    Assert.AreEqual(expectedAlbums[0].Title, actualAlbums[0].Title);
        //}

        //[Test]
        //public async Task GetAllPlaylists_ReturnsOkWithPlaylists()
        //{
        //    // Arrange
        //    var expectedPlaylists = new List<PlaylistDto> { new PlaylistDto { Id = 1, Name = "Playlist 1" }, new PlaylistDto { Id = 2, Name = "Playlist 2" } };
        //    mockSearchService.Setup(service => service.GetAllPlaylists()).ReturnsAsync(expectedPlaylists);

        //    // Act
        //    var result = await searchController.GetAllPlaylists();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualPlaylists = Assert.IsAssignableFrom<List<PlaylistDto>>(okResult.Value);
        //    Assert.AreEqual(expectedPlaylists.Count, actualPlaylists.Count);
        //    Assert.AreEqual(expectedPlaylists[0].Id, actualPlaylists[0].Id);
        //    Assert.AreEqual(expectedPlaylists[0].Name, actualPlaylists[0].Name);
        //}

        //[Test]
        //public async Task GetAllStations_ReturnsOkWithStations()
        //{
        //    // Arrange
        //    var expectedStations = new List<StationDto> { new StationDto { Id = 1, Name = "Station 1" }, new StationDto { Id = 2, Name = "Station 2" } };
        //    mockSearchService.Setup(service => service.GetAllStations()).ReturnsAsync(expectedStations);

        //    // Act
        //    var result = await searchController.GetAllStations();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualStations = Assert.IsAssignableFrom<List<StationDto>>(okResult.Value);
        //    Assert.AreEqual(expectedStations.Count, actualStations.Count);
        //    Assert.AreEqual(expectedStations[0].Id, actualStations[0].Id);
        //    Assert.AreEqual(expectedStations[0].Name, actualStations[0].Name);
        //}

        //[Test]
        //public async Task GetAllSongs_ReturnsOkWithSongs()
        //{
        //    // Arrange
        //    var expectedSongs = new List<SongDto> { new SongDto { Id = 1, Title = "Song 1" }, new SongDto { Id = 2, Title = "Song 2" } };
        //    mockSearchService.Setup(service => service.GetAllSongs()).ReturnsAsync(expectedSongs);

        //    // Act
        //    var result = await searchController.GetAllSongs();

        //    // Assert
        //    var okResult = Assert.IsInstanceOf<OkObjectResult>(result.Result);
        //    var actualSongs = Assert.IsAssignableFrom<List<SongDto>>(okResult.Value);
        //    Assert.AreEqual(expectedSongs.Count, actualSongs.Count);
        //    Assert.AreEqual(expectedSongs[0].Id, actualSongs[0].Id);
        //    Assert.AreEqual(expectedSongs[0].Title, actualSongs[0].Title);
        //}

        //// Additional tests for other endpoints can be added similarly

        //// Example test for an error scenario (assuming service returns null)
        //[Test]
        //public async Task GetAll_ReturnsNotFoundWhenServiceReturnsNull()
        //{
        //    // Arrange
        //    mockSearchService.Setup(service => service.GetAllItems()).ReturnsAsync((List<SearchResponseDto>)null);

        //    // Act
        //    var result = await searchController.GetAll();

        //    // Assert
        //    Assert.IsInstanceOf<NotFoundResult>(result.Result);
        //}
    }
}
