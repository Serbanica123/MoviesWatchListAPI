using Microsoft.AspNetCore.Mvc;
using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Services;

namespace MoviesWatchListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        /// <summary>Returns all users with no filtering or ordering.</summary>
        /// <response code="200">List of all users.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.GetAllAsync();
            return Ok(users);
        }

        /// <summary>Finds a single user by their primary key.</summary>
        /// <param name="id">The user's primary key.</param>
        /// <response code="200">The matching user.</response>
        /// <response code="404">No user with that ID exists.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>Creates a new user and returns the created resource with its assigned ID.</summary>
        /// <param name="user">First and last name of the new user.</param>
        /// <response code="201">User created — Location header points to the new resource.</response>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserPostDto user)
        {
            var newUser = await userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        /// <summary>Deletes a user by their primary key.</summary>
        /// <param name="id">The user's primary key.</param>
        /// <response code="204">User successfully deleted.</response>
        /// <response code="404">No user with that ID exists.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await userService.DeleteUserAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
