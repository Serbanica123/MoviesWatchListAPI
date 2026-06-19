using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IUserRepository
    {
        /// <summary>Uses EF Core's identity cache to avoid a DB round-trip when the entity is already tracked.</summary>
        /// <param name="id">The user's primary key.</param>
        /// <returns>The matching user, or <c>null</c> if not found.</returns>
        Task<User?> GetByIdAsync(int id);

        /// <summary>Fetches every user record from the database with no filtering or ordering.</summary>
        /// <returns>A list of all users.</returns>
        Task<List<User>> GetAllAsync();

        /// <summary>Stages a new user entity in the context (not yet persisted).</summary>
        Task AddAsync(User user);

        /// <summary>Marks a user entity as modified so EF Core will persist changes on save.</summary>
        void Update(User user);

        /// <summary>Removes a user entity from the context (not yet persisted).</summary>
        void Delete(User user);

        /// <summary>Persists all pending changes tracked by the EF Core context to the database.</summary>
        Task SaveChangesAsync();
    }
}
