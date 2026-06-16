using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Data;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public class MovieRepository(AppDbContext dbContext) : IMovieRepository
    {
        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await dbContext.Movies.FindAsync(id);
        }

        public async Task<Movie?> GetByTitleAsync(string title)
        {
            return await dbContext.Movies.FirstOrDefaultAsync(x => x.Title == title);
        }

        public void Update(Movie movie)
        {
            dbContext.Movies.Update(movie);
        }

        public void Delete(Movie movie)
        {
            dbContext.Movies.Remove(movie);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
