using MoviesWatchListAPI.Models;

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
}
