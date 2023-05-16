using Movies.Entities.Movies;

namespace Movies.DTOS
{
    public class MovieRoomRequestDTO
    {
        public decimal Price { get; set; }  
        public MovieRoomEnumType Type { get; set; }
    }
}
