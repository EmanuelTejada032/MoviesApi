using System.ComponentModel.DataAnnotations;

namespace Movies.DTOS
{
    public class MovieTheaterRequestDTO
    {
        [Required]
        public string Name { get; set; }
        public MovieTheaterOfferRequestDTO offer { get; set; }
        public MovieRoomRequestDTO[] MovieRooms { get; set; }
    }
}
