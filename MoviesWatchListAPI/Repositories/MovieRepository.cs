using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Data;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public class MovieRepository(AppDbContext dbContext) : IMovieRepository
    {
        public async Task AddAsync(Movie movie)
        {
            await dbContext.Movies.AddAsync(movie);
        }

        public void Update(Movie movie)
        {
            dbContext.Movies.Update(movie);
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(x => x.Title == title);
        }
        public async Task<int?> GetIdByTitleAsync(string title)
        {
            var id = await dbContext.Movies.Where(m => m.Title == title)
                .Select(m => m.Id)
                .FirstOrDefaultAsync();
            return (id == 0) ? null : id;
        }
        public async Task<List<Movie>> GetMoviesAsync()
        {
            return await dbContext.Movies.ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByDescendingRatingAsync()
        {
            return await dbContext.Movies.OrderByDescending(m => m.AverageRating).ToListAsync();
        }
        public async Task<List<Movie>> GetMoviesByAscendingRatingAsync()
        {
            return await dbContext.Movies.OrderBy(m => m.AverageRating).ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(string genre)
        {
            return await dbContext.Movies.Where(m => m.Genre == genre).ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesPageListAsync(int page, int pageEntries)
        {
            return await dbContext.Movies.Skip((page - 1) * pageEntries)
                .Take(pageEntries)
                .ToListAsync();
        }

        public async Task<List<Movie>> SortByGenreAndRatingAsync()
        {
            return await dbContext.Movies.OrderBy(m => m.Genre)
                .ThenByDescending(m => m.AverageRating)
                .ToListAsync();        
        }

        public async Task<List<string>> GetGenresAsync()
        {
            return await dbContext.Movies.Select(m => m.Genre)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
