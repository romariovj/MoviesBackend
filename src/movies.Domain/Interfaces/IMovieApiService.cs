namespace movies.Domain.Interfaces
{
    public interface IMovieApiService
    {
        Task<string> GetTrendingMoviesAsync();
        Task<string> GetPopularMoviesAsync();
    }
}
