using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IMovieService
    {
        /// <summary>Fetches all movies from the repository and maps each entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <returns>A list of all movies as DTOs.</returns>
        Task<List<MovieDetailsDto>> GetAllMoviesAsync();

        /// <summary>Delegates descending sort to the repository, then maps each entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <returns>A list of movies ordered by rating descending.</returns>
        Task<List<MovieDetailsDto>> GetMoviesByDescendingRatingAsync();

        /// <summary>Delegates ascending sort to the repository, then maps each entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <returns>A list of movies ordered by rating ascending.</returns>
        Task<List<MovieDetailsDto>> GetMoviesByAscendingRatingAsync();

        /// <summary>Delegates pagination to the repository, then maps each entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <param name="page">1-based page number.</param>
        /// <param name="pageEntries">Number of movies per page.</param>
        /// <returns>A list of movies for the requested page.</returns>
        Task<List<MovieDetailsDto>> GetMoviesPageAsync(int page, int pageEntries);

        /// <summary>Delegates two-level sorting to the repository, then maps each entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <returns>A multi-sorted list of movies as DTOs.</returns>
        Task<List<MovieDetailsDto>> SortByGenreAndRatingAsync();

        /// <summary>
        /// Groups all movies in memory by genre and aggregates count and average rating per group.
        /// Done in memory because EF Core cannot always translate GroupBy + Average to a single SQL query.
        /// </summary>
        /// <returns>One <see cref="GenreStatsDto"/> per genre.</returns>
        Task<List<GenreStatsDto>> StatusPerGenreAsync();

        /// <summary>Delegates directly to the repository — no DTO mapping needed for scalar string values.</summary>
        /// <returns>An alphabetically sorted list of distinct genre strings.</returns>
        Task<List<string>> GetGenresAsync();

        /// <summary>Looks up a movie by primary key and maps the entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <param name="id">The movie's primary key.</param>
        /// <returns>The movie as a DTO, or <c>null</c> if not found.</returns>
        Task<MovieDetailsDto?> GetMovieByIdAsync(int id);

        /// <summary>Performs an exact title match and maps the entity to a <see cref="MovieDetailsDto"/>.</summary>
        /// <param name="title">Exact movie title to search for.</param>
        /// <returns>The movie as a DTO, or <c>null</c> if not found.</returns>
        Task<MovieDetailsDto?> GetMovieByTitleAsync(string title);

        /// <summary>Applies up to three optional filters on the movie table — only the provided parameters narrow the query.</summary>
        /// <param name="genre">Exact genre to filter by, or <c>null</c> to skip genre filtering.</param>
        /// <param name="minRating">Inclusive lower bound on AverageRating, or <c>null</c> to skip.</param>
        /// <param name="maxRating">Inclusive upper bound on AverageRating, or <c>null</c> to skip.</param>
        /// <returns>A list of movies matching all provided filters.</returns>
        Task<List<MovieDetailsDto>> FilterMoviesAsync(string? genre, float? minRating, float? maxRating);
    }
}
