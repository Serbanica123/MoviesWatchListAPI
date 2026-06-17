using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IMovieService
    {
        Task<List<MovieDetailsDto>> GetAllMoviesAsync();
        Task<List<MovieDetailsDto>> GetMoviesByDescendingRatingAsync();
        Task<List<MovieDetailsDto>> GetMoviesByAscendingRatingAsync();
        Task<MovieDetailsDto?> GetMovieByIdAsync(int id);
        Task<MovieDetailsDto?> GetMovieByTitleAsync(string title);
    }
}
