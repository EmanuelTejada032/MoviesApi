using System.ComponentModel.DataAnnotations;

namespace Movies.DTOS
{
    public class GenreRequestDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
