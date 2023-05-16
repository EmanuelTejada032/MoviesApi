
using System.ComponentModel.DataAnnotations;

namespace Movies.DTOS
{
    public class MovieTheaterOfferRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Range(1,100)]
        public decimal DiscountPercentaje { get; set; }
    }
}
