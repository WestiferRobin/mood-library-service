namespace MoodLibraryApi.Dtos.Responses
{
    public class ArtistResponseDto
    {
        public string Name { get; set; }
        public List<SongDto> TopTen { get; set; }
        public List<AlbumNameDto> Albums { get; set; }
    }
}