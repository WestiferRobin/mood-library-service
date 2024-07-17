using AutoMapper;
using MoodLibrary.Api.Models;
using MoodLibrary.Api.Dtos;

namespace MoodLibrary.Api.Mappers
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
