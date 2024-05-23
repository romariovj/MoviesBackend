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
        private readonly ApplicationDbContext _context;
        private const string PopularType = "Popular";
        private const string TrendingType = "Trending";

        public MovieRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
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
    }
}
