using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Dtos
{
    public class UserMovieUpdateDto
    {
        public bool Watched { get; set; }
        public float? Rating { get; set; }
    }
}
