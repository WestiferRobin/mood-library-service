using MoodLibraryApi.Repositories;
using MoodLibraryApi.Services;
using MoodLibraryApi.Db;
using MoodLibraryApi.Mappers;
// using MoodLibraryApi.Mappers;

namespace MoodLibraryApi
{
    public class Startup
    {
        private const bool IsLocal = true;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers();

            services.AddAutoMapper(typeof(ArtistMapper));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var connectionString = IsLocal ? "LocalDatabase" : "Database";
            PostgresContext.ConnectionString = Configuration.GetConnectionString(connectionString);

            services.AddScoped<IArtistService, ArtistService>();
            // services.AddScoped<IAlbumService, AlbumService>();
            // services.AddScoped<IPlaylistService, PlaylistService>();
            // services.AddScoped<IStationService, StationService>();

            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IStationRepository, StationRepository>();

            services.AddScoped<ISongRepository, SongRepository>();


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