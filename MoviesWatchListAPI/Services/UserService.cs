using MoviesWatchListAPI.Models;
using MoviesWatchListAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Dtos;


namespace MoviesWatchListAPI.Services
{
    public class UserService(IUserRepository repository) : IUserService
    {
        public async Task<UserDetailsDto?> GetByIdAsync(int id)
        {
            var foundUser = await repository.GetByIdAsync(id);

            if (foundUser is null)
            {
                return null;
            }

            return new UserDetailsDto
            {
                Id = foundUser.Id,
                FirstName = foundUser.FirstName,
                LastName = foundUser.LastName
            };
        }

        public async Task<List<UserDetailsDto>> GetAllAsync()
        {
            var users = await repository.GetAllAsync();
            return users.Select(user => new UserDetailsDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            }).ToList();
        }

        public async Task<UserDetailsDto> AddUserAsync(UserPostDto user)
        {
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            await repository.AddAsync(newUser);
            await repository.SaveChangesAsync();
            return new UserDetailsDto
            {
                Id = newUser.Id,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var foundUser = await repository.GetByIdAsync(id);
            if (foundUser is null)
            {
                return false;
            }
            repository.Delete(foundUser);
            await repository.SaveChangesAsync();
            return true;
        }
    }
}
