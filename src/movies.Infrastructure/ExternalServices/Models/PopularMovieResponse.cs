using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Infrastructure.ExternalServices.Models
{
    public class PopularMovieResponse
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public MovieIds Ids { get; set; }
    }
}
