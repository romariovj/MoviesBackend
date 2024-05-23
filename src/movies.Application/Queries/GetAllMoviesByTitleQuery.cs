using MediatR;
using movies.Application.Dtos;

namespace movies.Application.Queries
{
    public class GetAllMoviesByTitleQuery : IRequest<List<MovieSearchDto>>
    {
        public string Title { get; set; }
    }
}
