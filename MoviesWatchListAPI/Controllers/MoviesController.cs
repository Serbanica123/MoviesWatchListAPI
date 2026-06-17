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
    }
}