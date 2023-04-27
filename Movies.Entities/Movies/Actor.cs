using System.ComponentModel.DataAnnotations;

namespace Movies.Entities.Movies
{
    public class Actor
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime? Birthday { get; set; }
        public HashSet<MoviesActors> MoviesActors { get; set; }
    }
}
