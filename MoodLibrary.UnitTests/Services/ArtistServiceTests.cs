using Microsoft.Extensions.Logging;
using Moq;
using MoodLibrary.Api.Services;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;
using AutoMapper;

namespace MoodLibrary.UnitTests.Services
{
    [TestFixture]
    internal class ArtistServiceTests
    {
        private Mock<ILogger<ArtistService>> mockLogger;
        private Mock<IMapper> mockMapper;
        private Mock<IArtistRepository> mockRepository;
        private ArtistService service;
        private List<Artist> artistTestData;

        [SetUp]
        public void Setup()
        {
            // Initialize mocks
            mockLogger = new Mock<ILogger<ArtistService>>();
            mockMapper = new Mock<IMapper>();
            mockRepository = new Mock<IArtistRepository>();

            // Initialize the service with mocks
            service = new ArtistService(
                mockRepository.Object, 
                mockMapper.Object,
                mockLogger.Object
            );

            artistTestData = [
                new() { 
                    Id = Guid.NewGuid(), 
                    Name = "Artist 1",
                    Genre = "Rock"
                },
                new() { 
                    Id = Guid.NewGuid(), 
                    Name = "Artist 2",
                    Genre = "Metal"
                },
                new() { 
                    Id = Guid.NewGuid(), 
                    Name = "Artist 3",
                    Genre = "EDM"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Artist 4",
                    Genre = "Jazz"
                },
                new() {
                    Id = Guid.NewGuid(),
                    Name = "Artist 4",
                    Genre = "Classical"
                }
            ];
        }

        #region GetAllModels Tests
        [Test]
        public async Task GetAllModels_ReturnsArtists()
        {
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(artistTestData);

            var result = await service.GetAllModels();

            Assert.IsNotNull(result);
            Assert.AreEqual(artistTestData.Count, result.Count());

            int index = 0;
            foreach (var artist in artistTestData)
            {
                var expectedArtist = artistTestData[index];
                Assert.AreEqual(artist.Id, expectedArtist.Id);
                Assert.AreEqual(artist.Name, expectedArtist.Name);
                Assert.AreEqual(artist.Genre, expectedArtist.Genre);
                index += 1;
            }
        }

        [Test]
        public async Task GetAllModels_ThrowsNoArtistsException()
        {
            Assert.Inconclusive();
            // mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(new List<Artist>());
        }
        #endregion

        #region GetAll Tests

        [Test]
        public async Task GetAllArtists_ReturnsArtists()
        {
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(artistTestData);

            var result = await service.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(artistTestData.Count, result.Count());

            int index = 0;
            foreach (var artist in artistTestData)
            {
                var expectedArtist = artistTestData[index];
                Assert.AreEqual(artist.Name, expectedArtist.Name);
                Assert.AreEqual(artist.Genre, expectedArtist.Genre);
                index += 1;
            }
        }
        #endregion

        #region GetArtist Tests
        #endregion

        #region GetDiscography Tests
        #endregion

        #region AddArtist Tests
        #endregion

        #region AddDiscography Tests
        #endregion

        #region UpdateArtist Tests
        #endregion

        #region DeleteArtist Tests
        #endregion 
    }
}
