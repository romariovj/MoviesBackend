using movies.Domain.Entities;

namespace movies.Domain.Interfaces
{
    public interface IMovieApiService
    {
        Task<IReadOnlyList<Movie>> GetTrendingMoviesAsync();
        Task<IReadOnlyList<Movie>> GetPopularMoviesAsync();
    }
}
