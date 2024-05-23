using MediatR;
using movies.Application.Dtos;

namespace movies.Application.Queries
{
    public class GetAllMoviesByTypeQuery: IRequest<List<MovieDto>>
    {
        public string Type { get; set; }
    }
}
