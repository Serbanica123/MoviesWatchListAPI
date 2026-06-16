using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IUserService
    {
        Task<UserDetailsDto?> GetByIdAsync(int id);
        Task<List<UserDetailsDto>> GetAllAsync();
        Task<UserDetailsDto> AddUserAsync(UserPostDto user);
        Task<bool> DeleteUserAsync(int id);
    }
}
