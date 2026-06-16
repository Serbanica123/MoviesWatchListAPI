using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Dtos
{
    public class UserMovieDetailsDto
    {
        public string? MovieTitle { get; set; }
        public string? Genre { get; set; }
        public bool Watched { get; set; }
        public float? Rating { get; set; }
        public float? AverageRating { get; set; }
    }
}
