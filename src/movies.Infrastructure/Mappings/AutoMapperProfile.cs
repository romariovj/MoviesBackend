using AutoMapper;
using movies.Domain.Entities;
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
        }
    }
}
