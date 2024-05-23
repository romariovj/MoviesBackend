using AutoMapper;
using movies.Domain.Entities;
using movies.Infrastructure.ExternalServices.Models;
using movies.Infrastructure.Persistences.DataEntities;

namespace movies.Infrastructure.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Movie, MovieEntity>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));

            CreateMap<MovieEntity, Movie>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));

            CreateMap<PopularMovieResponse, Movie>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year));

            CreateMap<TrendingMovieResponse, Movie>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Movie.Title))
                //.ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Movie.Year));
        }
    }
}
