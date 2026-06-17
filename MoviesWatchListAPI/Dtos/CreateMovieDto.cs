using System.ComponentModel.DataAnnotations;

namespace MoviesWatchListAPI.Dtos
{
    public class CreateMovieDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Genre { get; set; } = string.Empty;
    }
}
