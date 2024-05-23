using movies.Domain.Entities;

namespace movies.Domain.Repositories
{
    public interface IMovieRepository: ICrudRepository<Movie, int>
    {
        Task SynchronizePopularMovies(IReadOnlyList<Movie> movies);
        Task SynchronizeTrendingMovies(IReadOnlyList<Movie> movies);
        Task<IReadOnlyList<Movie>> GetAllMoviesByType(string type);
        Task<IReadOnlyList<Movie>> GetAllMoviesByTitle(string title);
        Task<IReadOnlyList<Movie>> GetRandomMovies(int quantity);
    }
}
