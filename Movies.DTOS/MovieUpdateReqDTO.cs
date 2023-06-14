using System.ComponentModel.DataAnnotations;

namespace Movies.DTOS
{
    public class MovieUpdateReqDTO
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string PosterUrl { get; set; }
    }
}
