using movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Domain.Repositories
{
    public interface IMovieRepository: ICrudRepository<Movie, int>
    {
    }
}
