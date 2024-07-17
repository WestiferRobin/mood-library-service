using AutoMapper;
using MoodLibrary.Api.Dtos;
using MoodLibrary.Api.Dtos.Responses;
using MoodLibrary.Api.Services;

public class SearchService : ISearchService
{
    private readonly IArtistService artistService;
    private readonly IAlbumService albumService;
    private readonly IPlaylistService playlistService;
    private readonly IStationService stationService;
    private readonly ISongService songService;
    private readonly IMapper mapper;

    public SearchService(
        IArtistService artistService,
        IAlbumService albumService,
        IPlaylistService playlistService,
        IStationService stationService,
        ISongService songService,
        IMapper mapper
    )
    {
        this.artistService = artistService;
        this.albumService = albumService;
        this.playlistService = playlistService;
        this.stationService = stationService;
        this.songService = songService;
        this.mapper = mapper;
    }

    public async Task<SearchResponseDto> GetAllItems()
    {
        var artists = await GetAllArtists();
        var albums = await GetAllAlbums();
        var playlists = await GetAllPlaylists();
        var stations = await GetAllStations();
        var songs = await GetAllSongs();

        return new SearchResponseDto()
        {
            Artists = artists.ToList(),
            Albums = albums.ToList(),
            Playlists = playlists.ToList(),
            Stations = stations.ToList(),
            Songs = songs.ToList()
        };
    }

    public async Task<IEnumerable<SearchItemDto>> GetAllArtists()
    {
        var artists = await artistService.GetAllModels();
        return mapper.Map<IEnumerable<SearchItemDto>>(artists);
    }

    public async Task<IEnumerable<SearchItemDto>> GetAllAlbums()
    {
        var albums = await albumService.GetAllModels();
        return mapper.Map<IEnumerable<SearchItemDto>>(albums);
    }

    public async Task<IEnumerable<SearchItemDto>> GetAllPlaylists()
    {
        var playlists = await playlistService.GetAllModels();
        return mapper.Map<IEnumerable<SearchItemDto>>(playlists);
    }

    public async Task<IEnumerable<SearchItemDto>> GetAllStations()
    {
        var stations = await stationService.GetAllModels();
        return mapper.Map<IEnumerable<SearchItemDto>>(stations);
    }

    public async Task<IEnumerable<SearchItemDto>> GetAllSongs()
    {
        var songs = await songService.GetAllModels();
        return mapper.Map<IEnumerable<SearchItemDto>>(songs);
    }
}
