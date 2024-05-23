using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies.Domain.Entities
{
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Type { get; set; }
    }
}
