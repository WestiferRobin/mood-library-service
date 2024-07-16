namespace MoodLibraryApi.Dtos.Responses
{
    public class SearchResponseDto
    {
        public required List<SearchItemDto> Artists { get; set; }
        public required List<SearchItemDto> Albums { get; set; }
        public required List<SearchItemDto> Playlists { get; set; }
        public required List<SearchItemDto> Stations { get; set; }
        public required List<SearchItemDto> Songs { get; set; }
    }
}