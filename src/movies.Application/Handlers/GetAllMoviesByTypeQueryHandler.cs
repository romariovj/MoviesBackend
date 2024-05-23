using AutoMapper;
using MediatR;
using movies.Application.Dtos;
using movies.Application.Queries;
using movies.Domain.Entities;
using movies.Domain.Repositories;

namespace movies.Application.Handlers
{
    public class GetAllMoviesByTypeQueryHandler : IRequestHandler<GetAllMoviesByTypeQuery, List<MovieDto>>
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public GetAllMoviesByTypeQueryHandler(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetAllMoviesByTypeQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyList<Movie> movies = await _repository.GetAllMoviesByType(request.Type);
            return _mapper.Map<List<MovieDto>>(movies);
        }
    }
}
