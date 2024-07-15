using Microsoft.EntityFrameworkCore;
using MoodLibraryApi.Db;
using MoodLibraryApi.Models;

namespace MoodLibraryApi.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly PostgresContext context;

        public PlaylistRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Playlist>> GetAll()
        {
            return await context.Playlists.ToListAsync();
        }

        public async Task<Playlist> Get(Guid playlistId)
        {
            return await context.Playlists.FindAsync();
        }

        public async Task Add(Playlist playlist)
        {
            context.Playlists.Add(playlist);
            await context.SaveChangesAsync();
        }

        public async Task Update(Playlist playlist)
        {
            context.Playlists.Update(playlist);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Playlist playlist)
        {
            context.Playlists.Remove(playlist);
            await context.SaveChangesAsync();
        }

    }
}