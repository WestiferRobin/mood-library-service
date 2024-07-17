using MoodLibrary.Api.Repositories;
using MoodLibrary.Api.Services;
using MoodLibrary.Api.Db;
using MoodLibrary.Api.Mappers;
// using MoodLibrary.Api.Mappers;

namespace MoodLibrary.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<ISearchService, SearchService>();

            services.AddScoped<IArtistService, ArtistService>();

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IStationService, StationService>();

            services.AddScoped<ISongService, SongService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IStationRepository, StationRepository>();

            services.AddScoped<ISongRepository, SongRepository>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services.AddAutoMapper(typeof(SearchMapper));
            services.AddAutoMapper(typeof(ArtistMapper));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var isLocal = Configuration.GetValue<bool>("IsLocal");
            var connectionString = isLocal ? "LocalDatabase" : "Database";
            PostgresContext.ConnectionString = Configuration.GetConnectionString(connectionString);

            AddServices(services);

            AddRepositories(services);

            services.AddDbContext<PostgresContext>(options => Configuration.GetConnectionString(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("localhost:3000"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}