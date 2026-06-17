using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IUserMovieRepository
    {
        Task<List<Movie>> GetMoviesByUserIdAsync(int userId);
        Task<List<Movie>> GetMoviesByUserNameAsync(string firstName, string lastName);
        Task<List<float>> GetMovieRatingsByTitleAsync(string movieTitle);
        Task<List<float>> GetMovieRatingsByIdAsync(int movieId);
        Task<UserMovie?> GetByUserAndMovieAsync(int userId, int movieId);
        Task<List<Movie>> GetWatchedMoviesByUserAsync(int userId);
        Task AddAsync(UserMovie userMovie);
        void Update(UserMovie userMovie);
        void Delete(UserMovie userMovie);
        Task SaveChangesAsync();
    }
}
