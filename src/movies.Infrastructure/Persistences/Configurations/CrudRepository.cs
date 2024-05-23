using AutoMapper;
using Microsoft.EntityFrameworkCore;
using movies.Domain.Repositories;
using movies.Infrastructure.Persistences.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Infrastructure.Persistences.Configurations
{
    public abstract class CrudRepository<TDomain, TDatabase, ID> 
        : ICrudRepository<TDomain, ID>
        where TDomain : class
        where TDatabase : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        protected CrudRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TDomain>> GetAllAsync()
        {
            var entities = await _context.Set<TDatabase>()
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IReadOnlyList<TDomain>>(entities);
        }
    }
}
