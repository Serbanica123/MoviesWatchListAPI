using System.ComponentModel.DataAnnotations;

namespace MoviesWatchListAPI.Dtos
{
    public class UserMovieDetailsDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public bool Watched { get; set; }
        public float? Rating { get; set; }
        public DateTime AddedOn { get; set; }
    }
    public class UserMoviePostDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Genre { get; set; } = string.Empty;

        public bool Watched { get; set; }

        [Range(1.0, 10.0, ErrorMessage = "Rating must be between 1 and 10")]
        public float? Rating { get; set; }
    }

    public class UserMovieUpdateDto
    {
        public bool Watched { get; set; }

        [Range(1.0, 10.0, ErrorMessage = "Rating must be between 1 and 10")]
        public float? Rating { get; set; }
    }
}
