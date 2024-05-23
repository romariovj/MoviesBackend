using movies.Domain.Entities;

namespace movies.Domain.Repositories
{
    public interface IMovieRepository: ICrudRepository<Movie, int>
    {
        Task SynchronizePopularMovies(IReadOnlyList<Movie> movies);
        Task SynchronizeTrendingMovies(IReadOnlyList<Movie> movies);
    }
}
