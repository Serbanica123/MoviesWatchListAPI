using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IUserMovieRepository
    {
        /// <summary>Joins UserMovies to Movies and filters by the given user ID.</summary>
        /// <param name="userId">The user whose watchlist to retrieve.</param>
        /// <returns>A list of movies on the user's watchlist.</returns>
        Task<List<Movie>> GetMoviesByUserIdAsync(int userId);

        /// <summary>Traverses the User navigation property on UserMovie to filter by name, avoiding a separate Users query.</summary>
        /// <param name="firstName">User's first name (exact match).</param>
        /// <param name="lastName">User's last name (exact match).</param>
        /// <returns>A list of movies on the matched user's watchlist.</returns>
        Task<List<Movie>> GetMoviesByUserNameAsync(string firstName, string lastName);

        /// <summary>
        /// Filters the pivot table on a movie title match and excludes null ratings.
        /// Used downstream to recalculate the movie's AverageRating.
        /// </summary>
        /// <param name="movieTitle">Exact title of the movie to collect ratings for.</param>
        /// <returns>A flat list of rating values (nulls excluded).</returns>
        Task<List<float>> GetMovieRatingsByTitleAsync(string movieTitle);

        /// <summary>
        /// Preferred over the title variant when the ID is already known — avoids an extra join on the Title column.
        /// Used downstream to recalculate the movie's AverageRating.
        /// </summary>
        /// <param name="movieId">Primary key of the movie to collect ratings for.</param>
        /// <returns>A flat list of rating values (nulls excluded).</returns>
        Task<List<float>> GetMovieRatingsByIdAsync(int movieId);

        /// <summary>Looks up a pivot record using both halves of the composite primary key.</summary>
        /// <param name="userId">The user's ID.</param>
        /// <param name="movieId">The movie's ID.</param>
        /// <returns>The watchlist entry, or <c>null</c> if the movie is not on the user's list.</returns>
        Task<UserMovie?> GetByUserAndMovieAsync(int userId, int movieId);

        /// <summary>Filters the UserMovies pivot table on both user ID and <c>Watched == true</c>.</summary>
        /// <param name="userId">The user whose watched movies to retrieve.</param>
        /// <returns>A list of watched movies for the user.</returns>
        Task<List<Movie>> GetWatchedMoviesByUserAsync(int userId);

        /// <summary>Stages a new watchlist entry in the context (not yet persisted).</summary>
        Task AddAsync(UserMovie userMovie);

        /// <summary>Marks a watchlist entry as modified so EF Core will persist changes on save.</summary>
        void Update(UserMovie userMovie);

        /// <summary>Removes a watchlist entry from the context (not yet persisted).</summary>
        void Delete(UserMovie userMovie);

        /// <summary>Persists all pending changes tracked by the EF Core context to the database.</summary>
        Task SaveChangesAsync();
    }
}
