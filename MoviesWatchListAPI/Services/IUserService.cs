using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IUserService
    {
        /// <summary>Looks up a user by primary key and maps the entity to a <see cref="UserDetailsDto"/>.</summary>
        /// <param name="id">The user's primary key.</param>
        /// <returns>The user as a DTO, or <c>null</c> if not found.</returns>
        Task<UserDetailsDto?> GetByIdAsync(int id);

        /// <summary>Fetches all user records from the repository and maps each entity to a <see cref="UserDetailsDto"/>.</summary>
        /// <returns>A list of all users as DTOs.</returns>
        Task<List<UserDetailsDto>> GetAllAsync();

        /// <summary>
        /// Builds a <see cref="User"/> entity from the supplied DTO, persists it, then reads the DB-assigned ID.
        /// The ID is only available after <c>SaveChanges</c> completes.
        /// </summary>
        /// <param name="user">First and last name of the new user.</param>
        /// <returns>The created user as a DTO including the database-assigned ID.</returns>
        Task<UserDetailsDto> AddUserAsync(UserPostDto user);

        /// <summary>Looks up the user, removes it from the context, and persists the deletion.</summary>
        /// <param name="id">The user's primary key.</param>
        /// <returns><c>true</c> if deleted successfully, <c>false</c> if no user with that ID exists.</returns>
        Task<bool> DeleteUserAsync(int id);
    }
}
