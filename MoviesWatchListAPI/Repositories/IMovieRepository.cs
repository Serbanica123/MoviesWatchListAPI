using MoviesWatchListAPI.Models;
using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Repositories
{
    public interface IMovieRepository
    {
        /// <summary>Uses EF Core's identity cache to avoid a DB round-trip when the entity is already tracked.</summary>
        /// <param name="id">The movie's primary key.</param>
        /// <returns>The matching movie, or <c>null</c> if not found.</returns>
        Task<Movie?> GetByIdAsync(int id);

        /// <summary>Performs an exact case-sensitive match against the Title column.</summary>
        /// <param name="title">Exact movie title to search for.</param>
        /// <returns>The matching movie, or <c>null</c> if not found.</returns>
        Task<Movie?> GetByTitleAsync(string title);

        /// <summary>
        /// Projects only the ID column to avoid fetching the full entity.
        /// Returns <c>null</c> when EF Core returns the int default of 0 (no match).
        /// </summary>
        /// <param name="title">Exact movie title to look up.</param>
        /// <returns>The movie's ID, or <c>null</c> if not found.</returns>
        Task<int?> GetIdByTitleAsync(string title);

        /// <summary>Marks a movie entity as modified so EF Core will persist changes on save.</summary>
        void Update(Movie movie);

        /// <summary>Stages a new movie entity in the context (not yet persisted).</summary>
        Task AddAsync(Movie movie);

        /// <summary>Fetches the full, unfiltered movie catalog from the database.</summary>
        /// <returns>A list of all movies.</returns>
        Task<List<Movie>> GetMoviesAsync();

        /// <summary>Applies a descending sort on <c>AverageRating</c> before fetching.</summary>
        /// <returns>A list of movies ordered by rating descending.</returns>
        Task<List<Movie>> GetMoviesByDescendingRatingAsync();

        /// <summary>Applies an ascending sort on <c>AverageRating</c> before fetching.</summary>
        /// <returns>A list of movies ordered by rating ascending.</returns>
        Task<List<Movie>> GetMoviesByAscendingRatingAsync();

        /// <summary>Filters the movie table by an exact genre match.</summary>
        /// <param name="genre">Genre name to filter by (exact match).</param>
        /// <returns>A list of movies in the given genre.</returns>
        Task<List<Movie>> GetMoviesByGenreAsync(string genre);

        /// <summary>Applies <c>Skip</c> and <c>Take</c> to the movie table to support pagination.</summary>
        /// <param name="page">1-based page number.</param>
        /// <param name="pageEntries">Number of movies per page.</param>
        /// <returns>A list of movies for the requested page.</returns>
        Task<List<Movie>> GetMoviesPageListAsync(int page, int pageEntries);

        /// <summary>Applies a two-level sort: genre ascending, then rating descending within each genre.</summary>
        /// <returns>A multi-sorted list of movies.</returns>
        Task<List<Movie>> SortByGenreAndRatingAsync();

        /// <summary>Projects the Genre column, deduplicates with <c>Distinct</c>, and sorts alphabetically.</summary>
        /// <returns>An alphabetically sorted list of distinct genre strings.</returns>
        Task<List<string>> GetGenresAsync();
        /// <summary>Builds an <c>IQueryable</c> and conditionally chains <c>Where</c> clauses for each non-null parameter.</summary>
        /// <param name="genre">Exact genre to filter by, or <c>null</c> to skip genre filtering.</param>
        /// <param name="minRating">Inclusive lower bound on AverageRating, or <c>null</c> to skip.</param>
        /// <param name="maxRating">Inclusive upper bound on AverageRating, or <c>null</c> to skip.</param>
        /// <returns>A list of movies matching all provided filters.</returns>
        Task<List<Movie>> FilterMoviesAsync(string? genre, float? minRating, float? maxRating);
        /// <summary>Persists all pending changes tracked by the EF Core context to the database.</summary>
        Task SaveChangesAsync();
    }
}
