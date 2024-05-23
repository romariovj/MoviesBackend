using AutoMapper;
using MediatR;
using movies.Application.Dtos;
using movies.Application.Queries;
using movies.Domain.Entities;
using movies.Domain.Repositories;

namespace movies.Application.Handlers
{
    public class GetAllMoviesByTitleQueryHandler : IRequestHandler<GetAllMoviesByTitleQuery, List<MovieSearchDto>>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMoviesByTitleQueryHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieSearchDto>> Handle(GetAllMoviesByTitleQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Movie> movies = await _repository.GetAllMoviesByTitle(request.Title);
            return _mapper.Map<List<MovieSearchDto>>(movies);
        }
    }
}
