using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Data;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public class UserMovieRepository(AppDbContext dbContext) : IUserMovieRepository
    {
        public async Task<List<Movie>> GetMoviesByUserIdAsync(int userId)
        {
            return await dbContext.UserMovies
                .Where(um => um.UserId == userId && um.Movie != null)
                .Select(um => um.Movie!)
                .ToListAsync();
        }
        public async Task<List<Movie>> GetWatchedMoviesByUserAsync(int userId)
        {
            return await dbContext.UserMovies
                .Where(um => um.UserId == userId && um.Watched == true)
                .Select(um => um.Movie!)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByUserNameAsync(string firstName, string lastName)
        {
            return await dbContext.UserMovies
                .Where(um => um.User!.FirstName == firstName && um.User!.LastName == lastName && um.Movie != null)
                .Select(um => um.Movie!)
                .ToListAsync();
        }

        public async Task<List<float>> GetMovieRatingsByTitleAsync(string movieTitle)
        {
            return await dbContext.UserMovies
                .Where(um => um.Movie!.Title == movieTitle && um.Rating.HasValue)
                .Select(um => um.Rating!.Value)
                .ToListAsync();
        }

        public async Task<List<float>> GetMovieRatingsByIdAsync(int movieId)
        {
            return await dbContext.UserMovies
                .Where(um => um.Movie!.Id == movieId && um.Rating.HasValue)
                .Select(um => um.Rating!.Value)
                .ToListAsync();
        }

        public async Task<UserMovie?> GetByUserAndMovieAsync(int userId, int movieId)
        {
            return await dbContext.UserMovies
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == movieId);
        }

        public async Task AddAsync(UserMovie userMovie)
        {
            await dbContext.UserMovies.AddAsync(userMovie);
        }

        public void Update(UserMovie userMovie)
        {
            dbContext.UserMovies.Update(userMovie);
        }

        public void Delete(UserMovie userMovie)
        {
            dbContext.UserMovies.Remove(userMovie);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
