using AutoMapper;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Exceptions;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Repositories;

namespace MoodLibrary.Api.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository repository;
        private readonly ILogger<ArtistService> logger;
        private readonly IMapper mapper;

        public ArtistService(
            IArtistRepository repository, 
            ILogger<ArtistService> logger,
            IMapper mapper
        )
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ArtistDto>> GetAllArtists()
        {
            var artists = await repository.GetAllArtists();
            if (!artists.Any()) throw new NoArtistsException();

            logger.LogInformation($"Found {artists.Count()} Artists");

            var artistDtos = mapper.Map<IEnumerable<ArtistDto>>(artists);
            
            return artistDtos;
        }

        public async Task<ArtistDto> GetArtist(Guid artistId)
        {
            var artist = await repository.GetArtist(artistId) ?? throw new NoArtistsException();
            
            logger.LogInformation($"Found {artist.Name} with {artistId}");
            
            var artistDto = mapper.Map<ArtistDto>(artist);
            return artistDto;
        }

        public async Task AddArtist(ArtistDto artist)
        {
            if (artist == null) throw new InvalidParamException("Artist param is null");
            
            var model = mapper.Map<Artist>(artist);
            await repository.AddArtist(model);

            logger.LogInformation($"Added {artist.Name}");
        }

        public async Task UpdateArtist(Guid artistId, ArtistDto artist)
        {
            if (artist == null) throw new InvalidParamException("Artist param is null");
            
            var model = await repository.GetArtist(artistId) ?? throw new NoArtistsException();
            if (artist.Name != null)
            {
                model.Name = artist.Name;
            }
            if (artist.Genre != null)
            {
                model.Genre = artist.Genre;
            }
            logger.LogInformation($"Updated Artist {model.Name}");
            
            await repository.UpdateArtist(model);
        }

        public async Task DeleteArtist(Guid artistId)
        {
            var model = await repository.GetArtist(artistId) ?? throw new NoArtistsException();
            
            logger.LogInformation($"Deleted Artist {model.Name} on {artistId}");
            
            await repository.DeleteArtist(model);
        }
    }
}