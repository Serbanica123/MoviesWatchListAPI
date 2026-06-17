using System.ComponentModel.DataAnnotations;

namespace MoviesWatchListAPI.Dtos
{
    public class UserMoviePostDto
    {
        [Required]
        [StringLength(50, MinimumLength =2)]
        public string? Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Genre { get; set; }
        public bool Watched { get; set; }
        [Range(1.0, 10.0, ErrorMessage = "Rating must be between 1 and 10")]
        public float? Rating { get; set; }

    }
}
