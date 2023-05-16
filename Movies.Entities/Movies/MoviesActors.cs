namespace Movies.Entities.Movies
{
    public class MoviesActors
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string CharacterName { get; set; }
        public int Order { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
    }
}
