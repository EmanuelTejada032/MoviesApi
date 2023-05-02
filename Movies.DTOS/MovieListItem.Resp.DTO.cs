using Movies.Entities.Movies;

namespace Movies.DTOS
{
    public class MovieListItemResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool OnBillboard { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PosterUrl { get; set; }
        public ICollection<string> Genres { get; set; }
        public ICollection<string> Actors { get; set; }
    }
}
