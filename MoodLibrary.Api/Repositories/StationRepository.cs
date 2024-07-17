using Microsoft.EntityFrameworkCore;
using MoodLibrary.Api.Db;
using MoodLibrary.Api.Models;

namespace MoodLibrary.Api.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly PostgresContext context;

        public StationRepository(PostgresContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Station>> GetAll()
        {
            return await context.Stations.ToListAsync();
        }

        public async Task<Station> Get(Guid stationId)
        {
            var station = await context.Stations.FindAsync(stationId);
            return station!;
        }

        public async Task Add(Station station)
        {
            context.Stations.Add(station);
            await context.SaveChangesAsync();
        }

        public async Task Update(Station station)
        {
            context.Stations.Update(station);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Station station)
        {
            context.Stations.Remove(station);
            await context.SaveChangesAsync();
        }

    }
}