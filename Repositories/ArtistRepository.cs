using Microsoft.EntityFrameworkCore;
using MoodLibraryApi.Db;
using MoodLibraryApi.Models;

namespace MoodLibraryApi.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PostgresContext context;

        public ArtistRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await context.Artists.ToListAsync();
        }

        public async Task<Artist> GetById(Guid id)
        {
            return await context.Artists.FindAsync(id);
        }

        public async Task Add(Artist artist)
        {
            context.Artists.Add(artist);
            await context.SaveChangesAsync();
        }

        public async Task Update(Artist artist)
        {
            context.Artists.Update(artist);
            await context.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var artist = await GetById(id);
            context.Artists.Remove(artist);
            await context.SaveChangesAsync();
        }
    }
}