using Microsoft.AspNetCore.Mvc;
using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Services;

namespace MoviesWatchListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(IMovieService movieService) : ControllerBase
    {
        /// <summary>Returns all movies with no filtering or ordering.</summary>
        /// <response code="200">List of all movies.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        /// <summary>Returns all movies sorted from highest to lowest average rating.</summary>
        /// <response code="200">Sorted list of movies.</response>
        [HttpGet("sorted/descending")]
        public async Task<IActionResult> GetMoviesByDescendingRating()
        {
            var movies = await movieService.GetMoviesByDescendingRatingAsync();
            return Ok(movies);
        }

        /// <summary>Returns all movies sorted from lowest to highest average rating.</summary>
        /// <response code="200">Sorted list of movies.</response>
        [HttpGet("sorted/ascending")]
        public async Task<IActionResult> GetMoviesByAscendingRating()
        {
            var movies = await movieService.GetMoviesByAscendingRatingAsync();
            return Ok(movies);
        }

        /// <summary>Finds a single movie by its primary key.</summary>
        /// <param name="id">The movie's primary key.</param>
        /// <response code="200">The matching movie.</response>
        /// <response code="404">No movie with that ID exists.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        /// <summary>Finds a single movie by its exact title.</summary>
        /// <param name="title">Exact movie title to search for.</param>
        /// <response code="200">The matching movie.</response>
        /// <response code="404">No movie with that title exists.</response>
        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetMovieByTitle(string title)
        {
            var movie = await movieService.GetMovieByTitleAsync(title);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        /// <summary>Returns a sorted list of all unique genre names across all movies.</summary>
        /// <response code="200">Alphabetically sorted list of genre strings.</response>
        [HttpGet("genres/ascending")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await movieService.GetGenresAsync();
            return Ok(genres);
        }

        /// <summary>Returns a paginated slice of all movies.</summary>
        /// <param name="page">1-based page number.</param>
        /// <param name="entries">Number of movies per page.</param>
        /// <response code="200">The requested page of movies.</response>
        [HttpGet("/movies/{page}/{entries}")]
        public async Task<IActionResult> GetMoviesPage(int page, int entries)
        {
            var movies = await movieService.GetMoviesPageAsync(page, entries);
            return Ok(movies);
        }

        /// <summary>Returns all movies sorted by genre A→Z, then by rating highest-first within each genre.</summary>
        /// <response code="200">Multi-sorted list of movies.</response>
        [HttpGet("/movies/sorted/genre/rating")]
        public async Task<IActionResult> SortedByGenreRating()
        {
            var sortedMovies = await movieService.SortByGenreAndRatingAsync();
            return Ok(sortedMovies);
        }

        /// <summary>Returns per-genre statistics: movie count and average rating for each genre.</summary>
        /// <response code="200">List of genre stats grouped by genre name.</response>
        [HttpGet("/movies/genre-stats")]
        public async Task<IActionResult> GetGenreStats()
        {
            var genreStats = await movieService.StatusPerGenreAsync();
            return Ok(genreStats);
        }

        [HttpGet ("/movies/filter")]

        public async Task<IActionResult> FilterMovies([FromQuery] string? genre, [FromQuery] float? minRating, [FromQuery] float? maxRating)
        {
            var filteredMovies = await movieService.FilterMoviesAsync(genre, minRating, maxRating);
            return Ok(filteredMovies);
        }
    }
}
