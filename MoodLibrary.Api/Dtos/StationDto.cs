namespace MoodLibrary.Api.Dtos
{
    public class StationDto
    {
        public required string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}