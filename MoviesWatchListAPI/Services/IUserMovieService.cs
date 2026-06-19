using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IUserMovieService
    {
        /// <summary>
        /// Adds a movie to a user's watchlist. Creates the movie globally if it doesn't exist,
        /// or updates the existing entry if the movie is already on the user's list.
        /// </summary>
        /// <param name="userId">The user adding the movie.</param>
        /// <param name="userMovie">Movie details, watch status, and optional rating.</param>
        /// <returns>The created or updated watchlist entry, or <c>null</c> on failure.</returns>
        Task<UserMovieDetailsDto?> AddUserMovieAsync(int userId, UserMoviePostDto userMovie);

        /// <summary>
        /// Applies the new watch status and rating to the pivot record, then recalculates
        /// the movie's global average rating across all user submissions.
        /// </summary>
        /// <param name="userId">The user whose entry to update.</param>
        /// <param name="movieTitle">Exact title of the movie to update.</param>
        /// <param name="userMovie">New watched status and rating.</param>
        /// <returns>The updated entry, or <c>null</c> if the movie or entry doesn't exist.</returns>
        Task<UserMovieDetailsDto?> UpdateUserMovieAsync(int userId, string movieTitle, UserMovieUpdateDto userMovie);

        /// <summary>Delegates to the repository to filter the pivot table, then maps results to <see cref="MovieDetailsDto"/>.</summary>
        /// <param name="userId">The user whose watched movies to retrieve.</param>
        /// <returns>A list of watched movies as DTOs.</returns>
        Task<List<MovieDetailsDto>> GetUserWatchedMoviesAsync(int userId);
    }
}
