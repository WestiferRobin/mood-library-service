namespace MoodLibraryApi.Dtos
{
    public class SearchItemDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}