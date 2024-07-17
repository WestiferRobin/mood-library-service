using Microsoft.EntityFrameworkCore;
using MoodLibrary.Api.Db;
using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly PostgresContext context;

        public AlbumRepository(PostgresContext context)
        {
            this.context = context;
        }
        
        public async Task<IEnumerable<Album>> GetAll()
        {
            return await context.Albums.ToListAsync();
        }
        public async Task<Album> Get(Guid id)
        {
            var album = await context.Albums.FindAsync(id);
            return album!;
        }
        public async Task Add(Album album)
        {
            context.Albums.Add(album);
            await context.SaveChangesAsync();
        }
        public async Task Update(Album album)
        {
            context.Albums.Update(album);
            await context.SaveChangesAsync();
        }
        public async Task Delete(Album album)
        {
            context.Albums.Remove(album);
            await context.SaveChangesAsync();
        }
    }
}