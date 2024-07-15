namespace MoodLibraryApi.Dtos
{
    public class DiscographyDto
    {
        public required ArtistDto Artist { get; set; }
        public required List<AlbumDto> Albums { get; set; }
    }
}