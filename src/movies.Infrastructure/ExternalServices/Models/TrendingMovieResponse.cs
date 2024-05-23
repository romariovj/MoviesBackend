namespace movies.Infrastructure.ExternalServices.Models
{
    public class TrendingMovieResponse
    {
        public int Watchers { get; set; }
        public MovieTrakt Movie { get; set; }
    }
}
