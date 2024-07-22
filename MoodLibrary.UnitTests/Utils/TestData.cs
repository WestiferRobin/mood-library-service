using MoodLibrary.Api.Models;

namespace MoodLibrary.UnitTests.Utils
{
    public class TestData
    {
        public static readonly List<Artist> ArtistData = [
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
}