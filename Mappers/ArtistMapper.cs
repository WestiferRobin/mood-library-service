using AutoMapper;
using MoodLibraryApi.Models;
using MoodLibraryApi.Dtos;

namespace MoodLibraryApi.Mappers
{
    public class ArtistMapper : Profile
    {
        public ArtistMapper()
        {
            CreateMap<Artist, ArtistDto>();
            // Add other mappings if necessary
        }
    }
}
