
namespace Movies.Entities.Movies
{
    public class Genre
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public HashSet<Movie>? Movies { get; set; }
    }
}
