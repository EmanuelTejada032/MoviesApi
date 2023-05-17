
namespace Movies.Entities.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public List<Genre> Genres { get; set; }
        public List<MovieRoom> MovieRooms { get; set; }
        public List<MoviesActors> MoviesActors { get; set; }

    }
}
