using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);

        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        void Update(User User);
        void Delete(User User);
        Task SaveChangesAsync();
    }
}
