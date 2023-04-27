using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Entities.Movies
{
    public class MovieTheater
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MovieTheaterOffer offer { get; set; }
        public HashSet<MovieRoom> MovieRooms { get; set; }
    }
}
