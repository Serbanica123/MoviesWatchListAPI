namespace MoviesWatchListAPI.Dtos
{
    public class MovieDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public float AverageRating { get; set; }
    }
}
