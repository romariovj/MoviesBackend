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

        [HttpGet("search")]
        [SwaggerOperation(Summary = "Buscar peliculas por titulo", Description = "Buscar peliculas por titulo.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Busqueda de peliculas", typeof(List<MovieSearchDto>))]
        public async Task<IActionResult> SearchMovies([FromQuery] string title)
        {
            var query = new GetAllMoviesByTitleQuery();
            query.Title = title;

            var movies = await _mediator.Send(query);
            return Ok(movies);
        }

        [HttpGet("home")]
        [SwaggerResponse(StatusCodes.Status200OK, "Lista de peliculas", typeof(List<MovieDto>))]
        public async Task<IActionResult> GetHomeMovies()
        {
            var query = new GetRandomMoviesQuery();
            query.Quantity = 10;

            var movies = await _mediator.Send(query);
            return Ok(movies);
        }
    }
}
