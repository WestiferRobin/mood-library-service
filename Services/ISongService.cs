using MoodLibraryApi.Models.Songs;

namespace MoodLibraryApi.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAllModels();
    }
}