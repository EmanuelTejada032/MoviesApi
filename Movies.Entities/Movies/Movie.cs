using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Entities.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public HashSet<Genre> Genres { get; set; }
        public HashSet<MovieRoom> MovieRooms { get; set; }
        public HashSet<MoviesActors> MoviesActors { get; set; }

    }
}
