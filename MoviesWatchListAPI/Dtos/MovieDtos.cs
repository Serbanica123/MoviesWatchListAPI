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

    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public float AverageRating { get; set; }
    }

    public class UpdateMovieDto
    {
        public float AverageRating { get; set; }
    }

    public class GenreStatsDto
    {
        public string Genre { get; set; } = string.Empty;
        public int MovieCount { get; set; }
        public float AverageRating { get; set; }
    }
}
