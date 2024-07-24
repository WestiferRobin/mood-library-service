//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using Moq;
//using MoodLibrary.Api.Dtos;
//using MoodLibrary.Api.Exceptions;
//using MoodLibrary.Api.Models;
//using MoodLibrary.Api.Repositories;
//using MoodLibrary.Api.Services;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MoodLibrary.UnitTests.Services
//{
//    [TestFixture]
//    public class ArtistServiceTests
//    {
//        private Mock<IArtistRepository> mockRepository;
//        private Mock<ILogger<ArtistService>> mockLogger;
//        private Mock<IMapper> mockMapper;
//        private ArtistService service;

//        [SetUp]
//        public void SetUp()
//        {
//            mockRepository = new Mock<IArtistRepository>();
//            mockLogger = new Mock<ILogger<ArtistService>>();
//            mockMapper = new Mock<IMapper>();
//            service = new ArtistService(mockRepository.Object, mockLogger.Object, mockMapper.Object);
//        }

//        #region GetAllArtists

//        [Test]
//        public async Task GetAllArtists_ReturnsArtistDtos()
//        {
//            var artists = new List<Artist> { new Artist { Id = Guid.NewGuid(), Name = "Artist1" } };
//            var artistDtos = new List<ArtistDto> { new ArtistDto { Id = artists[0].Id, Name = "Artist1" } };

//            mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(artists);
//            mockMapper.Setup(m => m.Map<IEnumerable<ArtistDto>>(artists)).Returns(artistDtos);

//            var result = await service.GetAllArtists();

//            Assert.AreEqual(artistDtos, result);
//            mockLogger.Verify(l => l.LogInformation($"Found {artists.Count} Artists"), Times.Once);
//        }

//        [Test]
//        public void GetAllArtists_ThrowsNoArtistsException_WhenNoArtistsExist()
//        {
//            mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(new List<Artist>());

//            Assert.ThrowsAsync<NoArtistsException>(() => service.GetAllArtists());
//        }

//        #endregion

//        #region GetArtist

//        [Test]
//        public async Task GetArtist_ReturnsArtistDto()
//        {
//            var artistId = Guid.NewGuid();
//            var artist = new Artist { Id = artistId, Name = "Artist1" };
//            var artistDto = new ArtistDto { Id = artistId, Name = "Artist1" };

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);
//            mockMapper.Setup(m => m.Map<ArtistDto>(artist)).Returns(artistDto);

//            var result = await service.GetArtist(artistId);

//            Assert.AreEqual(artistDto, result);
//            mockLogger.Verify(l => l.LogInformation($"Found {artist.Name} with {artistId}"), Times.Once);
//        }

//        [Test]
//        public void GetArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//        {
//            var artistId = Guid.NewGuid();

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//            Assert.ThrowsAsync<NoArtistsException>(() => service.GetArtist(artistId));
//        }

//        #endregion

//        #region AddArtist

//        [Test]
//        public async Task AddArtist_AddsArtistSuccessfully()
//        {
//            var artistDto = new ArtistDto { Name = "Artist1" };
//            var artist = new Artist { Name = "Artist1" };

//            mockMapper.Setup(m => m.Map<Artist>(artistDto)).Returns(artist);

//            await service.AddArtist(artistDto);

//            mockRepository.Verify(r => r.AddArtist(artist), Times.Once);
//            mockLogger.Verify(l => l.LogInformation($"Added {artistDto.Name}"), Times.Once);
//        }

//        [Test]
//        public void AddArtist_ThrowsInvalidParamException_WhenArtistDtoIsNull()
//        {
//            Assert.ThrowsAsync<InvalidParamException>(() => service.AddArtist(null));
//        }

//        #endregion

//        #region UpdateArtist

//        [Test]
//        public async Task UpdateArtist_UpdatesArtistSuccessfully()
//        {
//            var artistId = Guid.NewGuid();
//            var artistDto = new ArtistDto { Name = "UpdatedName" };
//            var artist = new Artist { Id = artistId, Name = "OriginalName" };

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);

//            await service.UpdateArtist(artistId, artistDto);

//            mockRepository.Verify(r => r.UpdateArtist(artist), Times.Once);
//            mockLogger.Verify(l => l.LogInformation($"Updated Artist {artist.Name}"), Times.Once);
//        }

//        [Test]
//        public void UpdateArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//        {
//            var artistId = Guid.NewGuid();
//            var artistDto = new ArtistDto { Name = "UpdatedName" };

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//            Assert.ThrowsAsync<NoArtistsException>(() => service.UpdateArtist(artistId, artistDto));
//        }

//        [Test]
//        public void UpdateArtist_ThrowsInvalidParamException_WhenArtistDtoIsNull()
//        {
//            var artistId = Guid.NewGuid();

//            Assert.ThrowsAsync<InvalidParamException>(() => service.UpdateArtist(artistId, null));
//        }

//        #endregion

//        #region DeleteArtist

//        [Test]
//        public async Task DeleteArtist_DeletesArtistSuccessfully()
//        {
//            var artistId = Guid.NewGuid();
//            var artist = new Artist { Id = artistId, Name = "Artist1" };

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);

//            await service.DeleteArtist(artistId);

//            mockRepository.Verify(r => r.DeleteArtist(artist), Times.Once);
//            mockLogger.Verify(l => l.LogInformation($"Deleted Artist {artist.Name} on {artistId}"), Times.Once);
//        }

//        [Test]
//        public void DeleteArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//        {
//            var artistId = Guid.NewGuid();

//            mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//            Assert.ThrowsAsync<NoArtistsException>(() => service.DeleteArtist(artistId));
//        }

//        #endregion
//    }
//}
