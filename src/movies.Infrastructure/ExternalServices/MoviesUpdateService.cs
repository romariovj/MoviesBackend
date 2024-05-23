using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using movies.Domain.Interfaces;
using movies.Domain.Repositories;

namespace movies.Infrastructure.ExternalServices
{
    public class MoviesUpdateService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public MoviesUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdateMovies, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private async void UpdateMovies(object state)
        {
            using(var scope = _serviceProvider.CreateScope())
            {
                var movieService = scope.ServiceProvider.GetRequiredService<IMovieApiService>();
                var movieRepository = scope.ServiceProvider.GetRequiredService<IMovieRepository>();

                var trendingList = await movieService.GetTrendingMoviesAsync();
                var popularList = await movieService.GetPopularMoviesAsync();

                await movieRepository.SynchronizePopularMovies(popularList);
                await movieRepository.SynchronizeTrendingMovies(trendingList);
            }
        }
    }
}
