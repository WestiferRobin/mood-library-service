using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Exceptions;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;
using MoodLibrary.Api.Services;
using MoodLibrary.UnitTests.Utils;

namespace MoodLibrary.UnitTests.Services
{
   [TestFixture]
   public class ArtistServiceTests
   {
       private Mock<IArtistRepository> mockRepository;
       private Mock<ILogger<ArtistService>> mockLogger;
       private Mock<IMapper> mockMapper;
       private ArtistService service;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IArtistRepository>();
            mockLogger = new Mock<ILogger<ArtistService>>();
            mockMapper = new Mock<IMapper>();
            service = new ArtistService(mockRepository.Object, mockLogger.Object, mockMapper.Object);
        }

        #region GetAllArtists

        [Test]
        public async Task GetAllArtists_ReturnsListOfArtistDtos()
        {
            var artists = TestData.ArtistData;
            var artistDtos = TestData.GetArtistDtos();
            mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(artists);
            mockMapper.Setup(m => m.Map<IEnumerable<ArtistDto>>(artists)).Returns(artistDtos);

            var result = await service.GetAllArtists();

            Assert.AreEqual(artistDtos, result);
        }

        [Test]
        public void GetAllArtists_ThrowsNoArtistsException_WhenNoArtistsExist()
        {
            mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(new List<Artist>());

            Assert.ThrowsAsync<NoArtistsException>(() => service.GetAllArtists());
        }

        #endregion

        #region GetArtist

        [Test]
        public async Task GetArtist_ReturnsArtistDto()
        {
            var artist = TestData.ArtistData[0];
            var artistId = artist.Id;
            var artistDtos = TestData.GetArtistDtos();
            var artistDto = artistDtos[0];
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);
            mockMapper.Setup(m => m.Map<ArtistDto>(artist)).Returns(artistDto);

            var result = await service.GetArtist(artistId);

            Assert.AreEqual(artistDto, result);
        }

        [Test]
        public void GetArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
        {
            var artistId = Guid.NewGuid();
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

            Assert.ThrowsAsync<NoArtistsException>(() => service.GetArtist(artistId));
        }

        #endregion

        #region AddArtist

        [Test]
        public async Task AddArtist_AddsArtist()
        {
            var artist = TestData.ArtistData[0];
            var artistId = artist.Id;
            var artistDtos = TestData.GetArtistDtos();
            var artistDto = artistDtos[0];
            mockMapper.Setup(m => m.Map<Artist>(artistDto)).Returns(artist);

            await service.AddArtist(artistDto);

            mockRepository.Verify(r => r.AddArtist(artist), Times.Once);
        }

        [Test]
        public void AddArtist_ThrowsInvalidParamException_WhenArtistDtoIsNull()
        {
            Assert.ThrowsAsync<InvalidParamException>(() => service.AddArtist(null));
        }

        #endregion

        #region UpdateArtist

        [Test]
        public async Task UpdateArtist_UpdatesArtist_AllFields()
        {
            var existingArtist = TestData.ArtistData[0];
            var artistId = existingArtist.Id;
            var artistDto = new ArtistDto { Name = "Artist X", Genre = "X" };
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(existingArtist);

            mockRepository.Setup(r => r.UpdateArtist(It.IsAny<Artist>())).Callback<Artist>(a =>
            {
                Assert.AreEqual(artistId, a.Id);
                Assert.AreEqual("Artist X", a.Name);
                Assert.AreEqual("X", a.Genre);
            });

            await service.UpdateArtist(artistId, artistDto);

            mockRepository.Verify(
                r => r.UpdateArtist(
                    It.Is<Artist>(a =>
                        a.Id == artistId &&
                        a.Name == "Artist X" &&
                        a.Genre == "X"
                    )
                ), Times.Once);
        }

        [Test]
        public async Task UpdateArtist_UpdatesArtist_NameFieldOnly()
        {
            var existingArtist = TestData.ArtistData[0];
            var artistId = existingArtist.Id;
            var artistDto = new ArtistDto { Name = "Artist X" };
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(existingArtist);

            mockRepository.Setup(r => r.UpdateArtist(It.IsAny<Artist>())).Callback<Artist>(a =>
            {
                Assert.AreEqual(artistId, a.Id);
                Assert.AreEqual("Artist X", a.Name);
                Assert.AreEqual(existingArtist.Genre, a.Genre);
            });

            await service.UpdateArtist(artistId, artistDto);

            mockRepository.Verify(
                r => r.UpdateArtist(
                    It.Is<Artist>(a =>
                        a.Id == artistId &&
                        a.Name == "Artist X" &&
                        a.Genre == existingArtist.Genre
                    )
                ), Times.Once);
        }

        [Test]
        public async Task UpdateArtist_UpdatesArtist_GenreFieldOnly()
        {
            var existingArtist = TestData.ArtistData[0];
            var artistId = existingArtist.Id;
            var artistDto = new ArtistDto { Genre = "X" };
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(existingArtist);

            mockRepository.Setup(r => r.UpdateArtist(It.IsAny<Artist>())).Callback<Artist>(a =>
            {
                Assert.AreEqual(artistId, a.Id);
                Assert.AreEqual(existingArtist.Name, a.Name);
                Assert.AreEqual("X", a.Genre);
            });

            await service.UpdateArtist(artistId, artistDto);

            mockRepository.Verify(
                r => r.UpdateArtist(
                    It.Is<Artist>(a =>
                        a.Id == artistId &&
                        a.Name == existingArtist.Name &&
                        a.Genre == "X"
                    )
                ), Times.Once);
        }

        [Test]
        public void UpdateArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var artistDto = new ArtistDto { Name = "Updated Artist" };
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

            // Act & Assert
            Assert.ThrowsAsync<NoArtistsException>(() => service.UpdateArtist(artistId, artistDto));
        }

        #endregion

        #region DeleteArtist

        [Test]
        public async Task DeleteArtist_DeletesArtist()
        {
            var artist = TestData.ArtistData[0];
            var artistId = artist.Id;
            var artistDtos = TestData.GetArtistDtos();
            var artistDto = artistDtos[0];
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);

            await service.DeleteArtist(artistId);

            mockRepository.Verify(r => r.DeleteArtist(artist), Times.Once);
        }

        [Test]
        public void DeleteArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
        {
            var artistId = Guid.NewGuid();
            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

            Assert.ThrowsAsync<NoArtistsException>(() => service.DeleteArtist(artistId));
        }

        #endregion
    }
}
