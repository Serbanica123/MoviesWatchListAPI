using MoviesWatchListAPI.Models;
using MoviesWatchListAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Dtos;

namespace MoviesWatchListAPI.Services
{
    public interface IUserMovieService
    {
        Task<UserMovieDetailsDto?> AddUserMovieAsync(int userId, UserMoviePostDto userMovie);
        Task<UserMovieDetailsDto?> UpdateUserMovieAsync(int userId, string movieTitle, UserMovieUpdateDto userMovie);
        Task<List<MovieDetailsDto>> GetUserWatchedMoviesAsync(int userId);

    }
}
