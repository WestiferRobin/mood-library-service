using Microsoft.EntityFrameworkCore;
using MoodLibrary.Api.Db;
using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PostgresContext context;

        public ArtistRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await context.Artists.ToListAsync();
        }

        public async Task<Artist> GetArtist(Guid artistId)
        {
            return await context.Artists.FindAsync(artistId);
        }

        public async Task AddArtist(Artist artist)
        {
            context.Artists.Add(artist);
            await context.SaveChangesAsync();
        }

        public async Task UpdateArtist(Artist artist)
        {
            context.Artists.Update(artist);
            await context.SaveChangesAsync();
        }

        public async Task DeleteArtist(Artist artist)
        {
            context.Artists.Remove(artist);
            await context.SaveChangesAsync();
        }
    }
}