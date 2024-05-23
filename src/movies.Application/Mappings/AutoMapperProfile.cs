using AutoMapper;
using movies.Application.Dtos;
using movies.Domain.Entities;

namespace movies.Application.Mappings
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Movie, MovieDto>();
        }
    }
}
