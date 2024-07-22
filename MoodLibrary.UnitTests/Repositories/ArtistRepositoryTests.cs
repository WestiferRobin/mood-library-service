// using Microsoft.EntityFrameworkCore;
// using MoodLibrary.Api.Db;
// using MoodLibrary.Api.Models;
// using MoodLibrary.Api.Repositories;

// namespace MoodLibrary.UnitTests.Repositories
// {
//     [TestFixture]
//     public class ArtistRepositoryTests
//     {
//         private DbContextOptions<PostgresContext> dbContextOptions;
//         private PostgresContext context;
//         private ArtistRepository repository;

//         [SetUp]
//         public void SetUp()
//         {
//             dbContextOptions = new DbContextOptionsBuilder<PostgresContext>()
//                 .UseInMemoryDatabase(databaseName: "TestDatabase")
//                 .Options;
//             context = new PostgresContext(dbContextOptions);
//             repository = new ArtistRepository(context);
//         }

//         [TearDown]
//         public void TearDown()
//         {
//             context.Database.EnsureDeleted();
//             context.Dispose();
//         }

//         #region GetAllArtists

//         [Test]
//         public async Task GetAllArtists_ReturnsAllArtists()
//         {
//             // Arrange
//             var artists = new List<Artist>
//             {
//                 new Artist { Id = Guid.NewGuid(), Name = "Artist1" },
//                 new Artist { Id = Guid.NewGuid(), Name = "Artist2" }
//             };
//             context.Artists.AddRange(artists);
//             await context.SaveChangesAsync();

//             // Act
//             var result = await repository.GetAllArtists();

//             // Assert
//             Assert.AreEqual(artists.Count, result.Count());
//         }

//         #endregion

//         #region GetArtist

//         [Test]
//         public async Task GetArtist_ReturnsArtist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artist = new Artist { Id = artistId, Name = "Artist1" };
//             context.Artists.Add(artist);
//             await context.SaveChangesAsync();

//             // Act
//             var result = await repository.GetArtist(artistId);

//             // Assert
//             Assert.AreEqual(artist, result);
//         }

//         [Test]
//         public async Task GetArtist_ReturnsNull_WhenArtistDoesNotExist()
//         {
//             // Act
//             var result = await repository.GetArtist(Guid.NewGuid());

//             // Assert
//             Assert.IsNull(result);
//         }

//         #endregion

//         #region AddArtist

//         [Test]
//         public async Task AddArtist_AddsArtist()
//         {
//             // Arrange
//             var artist = new Artist { Id = Guid.NewGuid(), Name = "New Artist" };

//             // Act
//             await repository.AddArtist(artist);
//             var result = await context.Artists.FindAsync(artist.Id);

//             // Assert
//             Assert.AreEqual(artist, result);
//         }

//         #endregion

//         #region UpdateArtist

//         [Test]
//         public async Task UpdateArtist_UpdatesArtist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artist = new Artist { Id = artistId, Name = "Old Artist" };
//             context.Artists.Add(artist);
//             await context.SaveChangesAsync();

//             artist.Name = "Updated Artist";

//             // Act
//             await repository.UpdateArtist(artist);
//             var result = await context.Artists.FindAsync(artistId);

//             // Assert
//             Assert.AreEqual("Updated Artist", result.Name);
//         }

//         #endregion

//         #region DeleteArtist

//         [Test]
//         public async Task DeleteArtist_DeletesArtist()
//         {
//             // Arrange
//             var artistId = Guid.NewGuid();
//             var artist = new Artist { Id = artistId, Name = "Artist1" };
//             context.Artists.Add(artist);
//             await context.SaveChangesAsync();

//             // Act
//             await repository.DeleteArtist(artist);
//             var result = await context.Artists.FindAsync(artistId);

//             // Assert
//             Assert.IsNull(result);
//         }

//         #endregion
//     }
// }
