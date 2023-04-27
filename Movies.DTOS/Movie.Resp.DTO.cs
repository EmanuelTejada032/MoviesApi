
namespace Movies.DTOS
{
    public class MovieRespDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public HashSet<GenreRespDTO> Genres { get; set; }
        public HashSet<MovieTheaterRespDTO> MovieTheaters { get; set; }
        public HashSet<ActorRespDTO> Actors { get; set; }
    }
}
