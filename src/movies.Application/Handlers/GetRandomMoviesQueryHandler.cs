using AutoMapper;
using MediatR;
using movies.Application.Dtos;
using movies.Application.Queries;
using movies.Domain.Entities;
using movies.Domain.Repositories;

namespace movies.Application.Handlers
{
    public class GetRandomMoviesQueryHandler : IRequestHandler<GetRandomMoviesQuery, List<MovieSearchDto>>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public GetRandomMoviesQueryHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieSearchDto>> Handle(GetRandomMoviesQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Movie> movies = await _repository.GetAllAsync();
            var randomMovies = movies.OrderBy(m => Guid.NewGuid()).Take(request.Quantity).ToList();
            return _mapper.Map<List<MovieSearchDto>>(randomMovies);
        }
    }
}
