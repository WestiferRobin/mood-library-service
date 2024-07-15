using AutoMapper;
using MoodLibraryApi.Dtos;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository repository;
        private readonly ILogger<ArtistService> logger;
        private readonly IMapper mapper;

        public ArtistService(IArtistRepository repository, ILogger<ArtistService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ArtistDto>> GetAll()
        {
            var artists = await repository.GetAll();
            return mapper.Map<IEnumerable<ArtistDto>>(artists);
        }

        public async Task<ArtistDto> GetArtist(Guid artistId)
        {
            var artist = await repository.Get(artistId);
            return mapper.Map<ArtistDto>(artist);
        }

        public Task<DiscographyDto> GetDiscography(Guid artistId)
        {
            throw new NotImplementedException();
        }
    }
}
