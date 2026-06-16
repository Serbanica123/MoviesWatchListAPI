using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie?> GetByIdAsync(int id);

        Task<Movie?> GetByTitleAsync(string title);
        void Update(Movie movie);
        void Delete(Movie movie);

        Task SaveChangesAsync();
    }
}
