using MoodLibrary.Api.Models.Songs;

namespace MoodLibrary.Api.Services
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetAllModels();
    }
}