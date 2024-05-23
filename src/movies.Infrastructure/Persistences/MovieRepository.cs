using AutoMapper;
using movies.Domain.Entities;
using movies.Domain.Repositories;
using movies.Infrastructure.Persistences.Configurations;
using movies.Infrastructure.Persistences.Contexts;
using movies.Infrastructure.Persistences.DataEntities;

namespace movies.Infrastructure.Persistences
{
    public class MovieRepository : CrudRepository<Movie, MovieEntity, int>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
