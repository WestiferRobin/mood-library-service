namespace MoodLibrary.Api.Dtos
{
    public class PlaylistDto
    {
        public required string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}