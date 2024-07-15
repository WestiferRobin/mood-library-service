namespace MoodLibraryApi.Dtos
{

    public class AlbumNameDto
    {
        public string Name { get; set; }
    }

    public class AlbumDto: AlbumNameDto
    {
        public List<SongDto> Songs { get; set; }
    }
}