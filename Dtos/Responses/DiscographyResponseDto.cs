namespace MoodLibraryApi.Dtos.Responses
{
    public class DiscographyResponseDto
    {
        public string ArtistName { get; set; }
        public List<AlbumDto> Discography { get; set; }
    }
}