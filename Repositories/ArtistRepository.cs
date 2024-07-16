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

        public async Task<Artist> Get(Guid artistId)
        {
            var artist = await context.Artists.FindAsync(artistId);
            return artist!;
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

        public async Task Delete(Artist artist)
        {
            context.Artists.Remove(artist);
            await context.SaveChangesAsync();
        }

    }
}