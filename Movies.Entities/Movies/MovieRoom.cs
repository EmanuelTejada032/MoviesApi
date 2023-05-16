namespace Movies.Entities.Movies
{
    public class MovieRoom
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public MovieRoomEnumType Type { get; set; }
        public int MovieTheaterId { get; set; }
        public MovieTheater MovieTheater { get; set; }
        public HashSet<Movie> Movies { get; set; }
    }
}
