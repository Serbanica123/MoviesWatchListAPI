namespace MoviesWatchListAPI.Dtos
{
    public class UserMoviePostDto
    {
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public bool Watched { get; set; }
        public float? Rating { get; set; }

    }
}
