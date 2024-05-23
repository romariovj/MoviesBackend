using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movies.Domain.Entities;
using movies.Domain.Repositories;
using movies.Infrastructure.Persistences.Configurations;
using movies.Infrastructure.Persistences.Contexts;
using movies.Infrastructure.Persistences.DataEntities;

namespace movies.Infrastructure.Persistences
{
    public class MovieRepository : CrudRepository<Movie, MovieEntity, int>, IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const string PopularType = "Popular";
        private const string TrendingType = "Trending";

        public MovieRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SynchronizePopularMovies(IReadOnlyList<Movie> movies)
        {
            var existingMovies = _context.Movies.Where(m => m.Type.Equals(PopularType));
            _context.Movies.RemoveRange(existingMovies);
            await _context.SaveChangesAsync();

            foreach (var movie in movies)
            {
                _context.Movies.Add(new MovieEntity
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Type = PopularType,
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task SynchronizeTrendingMovies(IReadOnlyList<Movie> movies)
        {
            var existingMovies = _context.Movies.Where(m => m.Type.Equals(TrendingType));
            _context.Movies.RemoveRange(existingMovies);
            await _context.SaveChangesAsync();

            foreach (var movie in movies)
            {
                _context.Movies.Add(new MovieEntity
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Type = TrendingType,
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Movie>> GetAllMoviesByType(string type)
        {
            var entities = await _context.Movies
                .AsNoTracking()
                .Where(m => m.Type.Equals(type))
                .ToListAsync();
            return _mapper.Map<IReadOnlyList<Movie>>(entities);
        }
    }
}
