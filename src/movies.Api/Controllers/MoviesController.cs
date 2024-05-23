using MediatR;
using Microsoft.AspNetCore.Mvc;
using movies.Application.Dtos;
using movies.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace movies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Movies Backend")]
    public class MoviesController: ControllerBase
    {
        private readonly IMediator _mediator;
        private const string PopularType = "Popular";
        private const string TrendingType = "Trending";

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("trending")]
        [SwaggerOperation(Summary = "Obtener todas las peliculas en tendencia", Description = "Obtiene lista de películas en tendencia.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de peliculas", typeof(List<MovieDto>))]
        public async Task<IActionResult> GetTrendingMovies()
        {
            var query = new GetAllMoviesByTypeQuery();
            query.Type = TrendingType;

            var movies = await _mediator.Send(query);
            return Ok(movies);

        }

        [HttpGet("popular")]
        [SwaggerOperation(Summary = "Obtener todas las peliculas populares", Description = "Obtiene lista de películas populares.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de peliculas", typeof(List<MovieDto>))]
        public async Task<IActionResult> GetPopularMovies()
        {
            var query = new GetAllMoviesByTypeQuery();
            query.Type = PopularType;

            var movies = await _mediator.Send(query);
            return Ok(movies);

        }
    }
}
