// using AutoMapper;
// using Microsoft.Extensions.Logging;
// using Moq;
// using MoodLibrary.Api.Dtos;
// using MoodLibrary.Api.Exceptions;
// using MoodLibrary.Api.Models;
// using MoodLibrary.Api.Repositories;
// using MoodLibrary.Api.Services;

// namespace MoodLibrary.UnitTests.Services
// {
//     [TestFixture]
//     public class ArtistServiceTests
//     {
//         private Mock<IArtistRepository> mockRepository;
//         private Mock<ILogger<ArtistService>> mockLogger;
//         private Mock<IMapper> mockMapper;
//         private ArtistService service;

//         [SetUp]
//         public void SetUp()
//         {
//             mockRepository = new Mock<IArtistRepository>();
//             mockLogger = new Mock<ILogger<ArtistService>>();
//             mockMapper = new Mock<IMapper>();
//             service = new ArtistService(mockRepository.Object, mockLogger.Object, mockMapper.Object);
//         }

//         #region GetAllArtists

//         [Test]
//         public async Task GetAllArtists_ReturnsListOfArtistDtos()
//         {
//             // Arrange
//             var artists = new List<Artist> { new Artist { Id = Guid.NewGuid(), Name = "Artist1" } };
//             var artistDtos = new List<ArtistDto> { new ArtistDto { Name = "Artist1" } };
//             mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(artists);
//             mockMapper.Setup(m => m.Map<IEnumerable<ArtistDto>>(artists)).Returns(artistDtos);

//             // Act
//             var result = await service.GetAllArtists();

//             // Assert
//             Assert.AreEqual(artistDtos, result);
//         }

//         [Test]
//         public void GetAllArtists_ThrowsNoArtistsException_WhenNoArtistsExist()
//         {
//             // Arrange
//             mockRepository.Setup(r => r.GetAllArtists()).ReturnsAsync(new List<Artist>());

//             // Act & Assert
//             Assert.ThrowsAsync<NoArtistsException>(() => service.GetAllArtists());
//         }

//         #endregion

//         #region GetArtist

//         [Test]
//         public async Task GetArtist_ReturnsArtistDto()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artist = new Artist { Id = artistId, Name = "Artist1" };
//             var artistDto = new ArtistDto { Id = artistId, Name = "Artist1" };
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);
//             mockMapper.Setup(m => m.Map<ArtistDto>(artist)).Returns(artistDto);

//             // Act
//             var result = await service.GetArtist(artistId);

//             // Assert
//             Assert.AreEqual(artistDto, result);
//         }

//         [Test]
//         public void GetArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//             // Act & Assert
//             Assert.ThrowsAsync<NoArtistsException>(() => service.GetArtist(artistId));
//         }

//         #endregion

//         #region AddArtist

//         [Test]
//         public async Task AddArtist_AddsArtist()
//         {
//             // Arrange
//             var artistDto = new ArtistDto { Name = "New Artist" };
//             var artist = new Artist { Name = "New Artist" };
//             mockMapper.Setup(m => m.Map<Artist>(artistDto)).Returns(artist);

//             // Act
//             await service.AddArtist(artistDto);

//             // Assert
//             mockRepository.Verify(r => r.AddArtist(artist), Times.Once);
//         }

//         [Test]
//         public void AddArtist_ThrowsInvalidParamException_WhenArtistDtoIsNull()
//         {
//             // Act & Assert
//             Assert.ThrowsAsync<InvalidParamException>(() => service.AddArtist(null));
//         }

//         #endregion

//         #region UpdateArtist

//         [Test]
//         public async Task UpdateArtist_UpdatesArtist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artistDto = new ArtistDto { Name = "Updated Artist" };
//             var artist = new Artist { Id = artistId, Name = "Old Artist" };
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);

//             // Act
//             await service.UpdateArtist(artistId, artistDto);

//             // Assert
//             mockRepository.Verify(r => r.UpdateArtist(It.Is<Artist>(a => a.Id == artistId && a.Name == "Updated Artist")), Times.Once);
//         }

//         [Test]
//         public void UpdateArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artistDto = new ArtistDto { Name = "Updated Artist" };
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//             // Act & Assert
//             Assert.ThrowsAsync<NoArtistsException>(() => service.UpdateArtist(artistId, artistDto));
//         }

//         #endregion

//         #region DeleteArtist

//         [Test]
//         public async Task DeleteArtist_DeletesArtist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artist = new Artist { Id = artistId, Name = "Artist1" };
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync(artist);

//             // Act
//             await service.DeleteArtist(artistId);

//             // Assert
//             mockRepository.Verify(r => r.DeleteArtist(artist), Times.Once);
//         }

//         [Test]
//         public void DeleteArtist_ThrowsNoArtistsException_WhenArtistDoesNotExist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             mockRepository.Setup(r => r.GetArtist(artistId)).ReturnsAsync((Artist)null);

//             // Act & Assert
//             Assert.ThrowsAsync<NoArtistsException>(() => service.DeleteArtist(artistId));
//         }

//         #endregion
//     }
// }
