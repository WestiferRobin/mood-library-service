namespace MoodLibraryApi.Dtos.Responses
{
    public class AlbumResponseDto
    {
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
        public List<SongDto> Songs { get; set; }
    }
}