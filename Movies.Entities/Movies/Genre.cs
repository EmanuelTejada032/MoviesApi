
namespace Movies.Entities.Movies
{
    public class Genre
    {
        public int Identifier { get; set; }
        private string _name;
        public string Name { get => _name; set { _name =  value.ToLower(); } }
        public HashSet<Movie>? Movies { get; set; }
    }
}
