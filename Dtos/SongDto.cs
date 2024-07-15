namespace MoodLibraryApi.Dtos
{
    public class SongDto
    {
        public required string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class AlbumSongDto : SongDto
    {
        public int AlbumIndex { get; set; }
    }

    public class PlaylistSongDto : SongDto
    {
        public int PlaylistIndex { get; set; }
    }

    public class StationSongDto : SongDto
    {
        public int StationIndex { get; set; }
    }
}