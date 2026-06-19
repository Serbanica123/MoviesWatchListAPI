using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IMovieService
    {
        Task<List<MovieDetailsDto>> GetAllMoviesAsync();
        Task<List<MovieDetailsDto>> GetMoviesByDescendingRatingAsync();
        Task<List<MovieDetailsDto>> GetMoviesByAscendingRatingAsync();
        Task<List<MovieDetailsDto>> GetMoviesPageAsync(int page, int pageEntries);
        Task<List<MovieDetailsDto>> SortByGenreAndRatingAsync();
        Task<List<GenreStatsDto>> StatusPerGenreAsync();
        Task<List<string>> GetGenresAsync();
        Task<MovieDetailsDto?> GetMovieByIdAsync(int id);
        Task<MovieDetailsDto?> GetMovieByTitleAsync(string title);
    }
}
