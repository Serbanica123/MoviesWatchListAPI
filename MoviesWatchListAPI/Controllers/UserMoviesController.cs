using Microsoft.AspNetCore.Mvc;
using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Services;

namespace MoviesWatchListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserMoviesController(IUserMovieService userMovieService) : ControllerBase
    {
        [HttpPost("{userId}")]
        public async Task<IActionResult> AddUserMovie(int userId, UserMoviePostDto userMovie)
        {
            var result = await userMovieService.AddUserMovieAsync(userId, userMovie);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{userId}/{movieTitle}")]
        public async Task<IActionResult> UpdateUserMovie(int userId, string movieTitle, UserMovieUpdateDto userMovie)
        {
            var result = await userMovieService.UpdateUserMovieAsync(userId, movieTitle, userMovie);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{userId}/watched")]
        public async Task<IActionResult> GetUserWatchedMovies(int userId)
        {
            var movies = await userMovieService.GetUserWatchedMoviesAsync(userId);
            return Ok(movies);
        }
    }
}