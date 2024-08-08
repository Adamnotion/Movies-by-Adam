using AutoMapper;
using Movies.Services.MovieAPI.Models;
using Movies.Services.MovieAPI.Models.Dto;

namespace Movies.Services.MovieAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MovieDto, Movie>();
                config.CreateMap<Movie, MovieDto>();
            });
            return mappingConfig;
        }
    }
}
