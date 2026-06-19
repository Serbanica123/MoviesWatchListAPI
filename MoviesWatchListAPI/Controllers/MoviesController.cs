using Microsoft.AspNetCore.Mvc;
using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Services;

namespace MoviesWatchListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController(IMovieService movieService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetAllMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("sorted/descending")]
        public async Task<IActionResult> GetMoviesByDescendingRating()
        {
            var movies = await movieService.GetMoviesByDescendingRatingAsync();
            return Ok(movies);
        }

        [HttpGet("sorted/ascending")]
        public async Task<IActionResult> GetMoviesByAscendingRating()
        {
            var movies = await movieService.GetMoviesByAscendingRatingAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await movieService.GetMovieByIdAsync(id);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetMovieByTitle(string title)
        {
            var movie = await movieService.GetMovieByTitleAsync(title);

            if (movie is null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet("genres/ascending")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await movieService.GetGenresAsync();
            return Ok(genres);
        }

        [HttpGet ("/movies/{page}/{entries}")]

        public async Task<IActionResult> GetMoviesPage(int page, int entries)
        {
            var movies = await movieService.GetMoviesPageAsync(page, entries);
            return Ok(movies);
        }

        [HttpGet ("/movies/sorted/genre/rating")]

        public async Task<IActionResult> SortedByGenreRating()
        {
            var sortedMovies = await movieService.SortByGenreAndRatingAsync();

            return Ok(sortedMovies);
        }

        [HttpGet ("/movies/genre-stats")]
        public async Task<IActionResult> GetGenreStats()
        {
            var genreStats = await movieService.StatusPerGenreAsync();

            return Ok(genreStats);
        }
    }
}