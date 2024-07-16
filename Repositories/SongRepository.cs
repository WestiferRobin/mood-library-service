using Microsoft.EntityFrameworkCore;
using MoodLibraryApi.Db;
using MoodLibraryApi.Models.Songs;

namespace MoodLibraryApi.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly PostgresContext context;

        public SongRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Song>> GetAll()
        {
            return await context.Songs.ToListAsync();
        }

        public async Task<Song> Get(Guid songId)
        {
            var song = await context.Songs.FindAsync();
            return song!;
        }

        public async Task Add(Song song)
        {
            context.Songs.Add(song);
            await context.SaveChangesAsync();
        }

        public async Task Update(Song song)
        {
            context.Songs.Update(song);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Song song)
        {
            context.Songs.Remove(song);
            await context.SaveChangesAsync();
        }

    }
}