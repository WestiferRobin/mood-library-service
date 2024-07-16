using AutoMapper;
using MoodLibraryApi.Dtos;
using MoodLibraryApi.Models;
using MoodLibraryApi.Models.Songs;

namespace MoodLibraryApi.Mappers
{
    public class SearchMapper : Profile
    {
        public SearchMapper()
        {
            CreateMap<Artist, SearchItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Album, SearchItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Playlist, SearchItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Station, SearchItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Genre));

            CreateMap<Song, SearchItemDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}