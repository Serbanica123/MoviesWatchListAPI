using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie?> GetByTitleAsync(string title);
        Task<List<Movie>> GetMoviesAsync();
        Task<List<Movie>> GetMoviesByDescendingRatingAsync();
        Task<List<Movie>> GetMoviesByAscendingRatingAsync();
        Task<List<Movie>> GetMoviesByGenreAsync(string genre);
        Task SaveChangesAsync();
    }
}
