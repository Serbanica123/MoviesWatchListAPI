using Microsoft.AspNetCore.Mvc;
using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Services;

namespace MoviesWatchListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserMoviesController(IUserMovieService userMovieService) : ControllerBase
    {
        /// <summary>
        /// Adds a movie to a user's watchlist. If the movie doesn't exist globally it is created first.
        /// If the movie is already on the user's list, the existing entry is updated instead.
        /// </summary>
        /// <param name="userId">The user adding the movie.</param>
        /// <param name="userMovie">Movie details, watch status, and optional rating.</param>
        /// <response code="200">Entry created or updated successfully.</response>
        /// <response code="400">The operation could not be completed.</response>
        [HttpPost("{userId}")]
        public async Task<IActionResult> AddUserMovie(int userId, UserMoviePostDto userMovie)
        {
            var result = await userMovieService.AddUserMovieAsync(userId, userMovie);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Updates a user's watchlist entry — changes the watched status and/or rating,
        /// then recalculates the movie's global average rating.
        /// </summary>
        /// <param name="userId">The user whose entry to update.</param>
        /// <param name="movieTitle">Exact title of the movie to update.</param>
        /// <param name="userMovie">New watched status and rating.</param>
        /// <response code="200">Entry updated successfully.</response>
        /// <response code="404">No matching user–movie entry found.</response>
        [HttpPut("{userId}/{movieTitle}")]
        public async Task<IActionResult> UpdateUserMovie(int userId, string movieTitle, UserMovieUpdateDto userMovie)
        {
            var result = await userMovieService.UpdateUserMovieAsync(userId, movieTitle, userMovie);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        /// <summary>Returns all movies a user has marked as watched.</summary>
        /// <param name="userId">The user whose watched movies to retrieve.</param>
        /// <response code="200">List of watched movies for the user.</response>
        [HttpGet("{userId}/watched")]
        public async Task<IActionResult> GetUserWatchedMovies(int userId)
        {
            var movies = await userMovieService.GetUserWatchedMoviesAsync(userId);
            return Ok(movies);
        }

        /// <summary>Returns movies not yet on the user's watchlist, using a <c>NOT IN</c> subquery against the full catalog.</summary>
        /// <param name="userId">The user to generate recommendations for.</param>
        /// <response code="200">List of movies not on the user's watchlist.</response>
        [HttpGet("{userId}/recommendations")]
        public async Task<IActionResult> GetRecommendations(int userId)
        {
            var recommendations = await userMovieService.GetRecommendationsAsync(userId);
            return Ok(recommendations);
        }
    }
}
