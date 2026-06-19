using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie?> GetByTitleAsync(string title);
        Task<int?> GetIdByTitleAsync(string title);
        public void Update(Movie movie);
        Task AddAsync(Movie movie);
        Task<List<Movie>> GetMoviesAsync();
        Task<List<Movie>> GetMoviesByDescendingRatingAsync();
        Task<List<Movie>> GetMoviesByAscendingRatingAsync();
        Task<List<Movie>> GetMoviesByGenreAsync(string genre);
        Task<List<Movie>> GetMoviesPageListAsync(int page, int pageEntries);
        Task<List<Movie>> SortByGenreAndRatingAsync();
        Task<List<string>> GetGenresAsync();
        Task SaveChangesAsync();
    }
}
