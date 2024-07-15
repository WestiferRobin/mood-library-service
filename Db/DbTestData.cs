using MoodLibraryApi.Models;

namespace MoodLibraryApi.Db
{
    // TODO: Implement for test cases for unit and integration tests
    public class DbTestData
    {
        public static void InitTestData(PostgresContext context)
        {
            AddTestArtistsAndAlbums(context);
            AddTestSongs(context);
        }
        
        private static void AddTestArtistsAndAlbums(PostgresContext context)
        {
            var artistRegistry = new Dictionary<string, int>
            {
                { "Daft Punk", 4 },
                { "Deadmau5", 3 },
                { "Tiesto", 7 },
                { "Nine Inch Nails", 10 },
                { "TOOL", 6 },
                { "Metallica", 12 },
                { "Korn", 8 },
                { "Hans Zimmer", 5 },
                { "John Williams", 8 },
                { "My Chemical Romance", 4 }
            };

            var artists = artistRegistry.Select(pair => new Artist { Name = pair.Key }).ToList();
            context.Artists.AddRange(artists);
            context.SaveChanges();

            foreach (var artist in context.Artists.ToList())
            {
                var albumCount = artistRegistry[artist.Name];
                var albums = new List<Album>();
                for (int index = 0; index < albumCount; index++)
                {
                    var album = new Album
                    {
                        Name = $"{artist.Name}'s Album #{index + 1}",
                        ArtistId = artist.Id
                    };
                    albums.Add(album);
                }
                context.Albums.AddRange(albums);
                context.SaveChanges();
            }
        }

        private static void AddTestSongs(PostgresContext context)
        {
            var rand = new Random();
            var songs = new List<Song>();

            foreach (var artist in context.Artists.ToList())
            {
                var albums = context.Albums.Where(album => album.ArtistId == artist.Id).ToList();
                var songCount = albums.Count % 2 == 0 ? 6 : 9;
                foreach (var album in albums)
                {
                    for (int index = 0; index < songCount; index++)
                    {
                        var minutes = rand.Next(1, 5);
                        var seconds = rand.Next(0, 60);
                        var duration = new TimeSpan(0, minutes, seconds);

                        var song = new Song
                        {
                            Name = $"Track #{index + 1}",
                            Duration = duration,
                            AlbumId = album.Id,
                            ArtistId = artist.Id
                        };

                        songs.Add(song);
                    }
                }
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();
        }
    }
}
