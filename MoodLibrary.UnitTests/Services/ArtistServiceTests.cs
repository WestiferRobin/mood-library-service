using Microsoft.Extensions.Logging;
using Moq;
using MoodLibrary.Api.Services;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;
using AutoMapper;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Exceptions;

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
        public void GetAllModels_ThrowsNoArtistsException()
        {
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync([]);

            Assert.ThrowsAsync<NoArtistsException>(service.GetAllModels);
        }
        #endregion

        #region GetAll Tests
        [Test]
        public async Task GetAllArtists_ReturnsArtists()
        {
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(artistTestData);
            mockMapper.Setup(m => m.Map<IEnumerable<ArtistDto>>(It.IsAny<IEnumerable<Artist>>()))
                      .Returns((IEnumerable<Artist> src) => src.Select(a => new ArtistDto
                      {
                          Name = a.Name,
                          Genre = a.Genre
                      }).ToList());

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

        [Test]
        public void GetAll_ThrowsNoArtistsException()
        {
            mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync([]);

            Assert.ThrowsAsync<NoArtistsException>(service.GetAll);
        }
        #endregion

        #region GetArtist Tests
        [Test]
        public async Task GetArtist_ReturnArtist()
        {
            var sample = artistTestData[0];
            var id = sample.Id;

            mockRepository.Setup(repo => repo.Get(id)).ReturnsAsync(sample);
            mockMapper.Setup(m => m.Map<ArtistDto>(It.IsAny<Artist>()))
                      .Returns((Artist src) => new ArtistDto
                      {
                          Name = src.Name,
                          Genre = src.Genre
                      });

            var result = await service.GetArtist(id);

            Assert.AreEqual(sample.Name, result.Name);
            Assert.AreEqual(sample.Genre, result.Genre);
        }

        [Test]
        public void GetArtist_ThrowsNoArtist()
        {
            var artistId = Guid.NewGuid();
            // mockRepository.Setup(repo => repo.Get(artistId)).ReturnsAsync((Artist)null);

            Assert.ThrowsAsync<NoArtistsException>(async () => await service.GetArtist(artistId));
        }
        #endregion

        #region GetDiscography Tests
        // TODO: Do Discography Tests Last
        #endregion

        #region AddArtist Tests
        #endregion

        #region AddDiscography Tests
        // TODO: Do Discography Tests Last
        #endregion

        #region UpdateArtist Tests
        #endregion

        #region DeleteArtist Tests
        #endregion 
    }
}
