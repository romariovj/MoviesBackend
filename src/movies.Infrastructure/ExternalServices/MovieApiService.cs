using AutoMapper;
using Microsoft.Extensions.Configuration;
using movies.Domain.Entities;
using movies.Domain.Interfaces;
using movies.Infrastructure.ExternalServices.Models;
using System.Text.Json;

namespace movies.Infrastructure.ExternalServices
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public MovieApiService(HttpClient httpClient, IConfiguration configuration, IMapper mapper)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _mapper = mapper;

            _httpClient.BaseAddress = new System.Uri(_configuration["MoviExternalApi:BaseUrl"]);

            var headers = _configuration.GetSection("MoviExternalApi:Headers");
            foreach ( var header in headers.GetChildren() )
            {
                _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public async Task<IReadOnlyList<Movie>> GetPopularMoviesAsync()
        {
            string endpoint = _configuration["MoviExternalApi:PopularEndpoint"];
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var popularMovies = JsonSerializer.Deserialize<List<PopularMovieResponse>>(jsonResponse, jsonOptions);
            return _mapper.Map<IReadOnlyList<Movie>>(popularMovies);
        }

        public async Task<IReadOnlyList<Movie>> GetTrendingMoviesAsync()
        {
            string endpoint = _configuration["MoviExternalApi:TrendingEndpoint"];
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();
            var trendingMovies = JsonSerializer.Deserialize<List<TrendingMovieResponse>>(jsonResponse, jsonOptions);
            return _mapper.Map<IReadOnlyList<Movie>>(trendingMovies);
        }
    }
}
