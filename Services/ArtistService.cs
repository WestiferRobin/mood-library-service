using AutoMapper;
using MoodLibraryApi.Dtos;
using MoodLibraryApi.Models;
using MoodLibraryApi.Repositories;

namespace MoodLibraryApi.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository repository;
        private readonly IMapper mapper;

        public ArtistService(IArtistRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddArtist(ArtistDto artist)
        {
            var artistModel = mapper.Map<Artist>(artist);
            await repository.Add(artistModel);
        }

        public Task AddDiscography(DiscographyDto discography)
        {
            throw new NotImplementedException("Need to fix");
        }

        public async Task DeleteArtist(Guid id)
        {
            var artist = await repository.Get(id);
            await repository.Delete(artist);
        }

        public async Task<IEnumerable<Artist>> GetAllModels()
        {
            var artists = await repository.GetAll();
            return artists;
        }

        public async Task<IEnumerable<ArtistDto>> GetAll()
        {
            var artists = await GetAllModels();
            return mapper.Map<IEnumerable<ArtistDto>>(artists);
        }

        public async Task<ArtistDto> GetArtist(Guid artistId)
        {
            var artist = await repository.Get(artistId);
            return mapper.Map<ArtistDto>(artist);
        }

        public Task<DiscographyDto> GetDiscography(Guid artistId)
        {
            throw new NotImplementedException("Need to fix");
        }

        public async Task UpdateArtist(Guid id, ArtistDto artist)
        {
            var artistModel = await repository.Get(id);
            artistModel.Name = artist.Name;
            artistModel.Genre = artist.Genre;
            await repository.Update(artistModel);
        }
    }
}
