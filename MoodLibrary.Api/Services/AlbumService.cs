using AutoMapper;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Models.Songs;
using MoodLibrary.Api.Repositories;

namespace MoodLibrary.Api.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository repository;
        private readonly IMapper mapper;

        public AlbumService(
            IAlbumRepository repository, 
            IMapper mapper
        )
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Album>> GetAllModels()
        {
            return await repository.GetAll();
        }

        public async Task<IEnumerable<AlbumDto>> GetAll()
        {
            var albums = await GetAllModels();
            return mapper.Map<IEnumerable<AlbumDto>>(albums);
        }

        public async Task<Album> GetAlbumModel(Guid albumId)
        {
            var album = await repository.Get(albumId);
            return album;
        }

        public async Task<AlbumDto> GetAlbum(Guid albumId)
        {
            var album = await GetAlbumModel(albumId);
            return mapper.Map<AlbumDto>(album);
        }

        public async Task AddAlbum(AlbumDto album)
        {
            var model = mapper.Map<Album>(album);
            await repository.Add(model);
        }

        public async Task AddAlbumSongs(Guid id, IEnumerable<SongDto> songs)
        {
            var albumModel = await GetAlbumModel(id);
            foreach (var song in songs)
            {
                var songModel = mapper.Map<Song>(song);
                albumModel.Songs.Add(songModel);
            }
            await repository.Update(albumModel);
        }

        public async Task UpdateAlbum(AlbumDto album)
        {
            var model = mapper.Map<Album>(album);
            await repository.Update(model);
        }

        public async Task DeleteAlbum(Guid id)
        {
            var album = await GetAlbumModel(id);
            await repository.Delete(album);
        }
    }
}