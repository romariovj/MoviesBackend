using MediatR;
using movies.Application.Dtos;

namespace movies.Application.Queries
{
    public class GetRandomMoviesQuery : IRequest<List<MovieSearchDto>>
    {
        public int Quantity { get; set; }
    }
}
