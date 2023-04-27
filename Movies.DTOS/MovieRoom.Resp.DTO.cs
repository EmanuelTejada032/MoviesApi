using Movies.Entities.Movies;

namespace Movies.DTOS
{
    public class MovieRoomRespDTO
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public MovieRoomEnumType Type { get; set; }
    }
}
