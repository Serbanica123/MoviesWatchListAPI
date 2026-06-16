using Microsoft.EntityFrameworkCore;

using MoviesWatchListAPI.Data;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public class UserRepository(AppDbContext dbContext) : IUserRepository
    {
        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
        }
        public void Update(User user)
        {
            dbContext.Users.Update(user);
        }

        public void Delete(User user)
        {
            dbContext.Users.Remove(user);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
