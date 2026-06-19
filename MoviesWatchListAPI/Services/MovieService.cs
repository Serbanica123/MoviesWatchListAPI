using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Repositories;

namespace MoviesWatchListAPI.Services
{
    public class MovieService(IMovieRepository repository) : IMovieService
    {
        public async Task<List<MovieDetailsDto>> GetAllMoviesAsync()
        {
            var movies = await repository.GetMoviesAsync();
            return movies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> GetMoviesByDescendingRatingAsync()
        {
            var descendingMovies = await repository.GetMoviesByDescendingRatingAsync();
            return descendingMovies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> GetMoviesByAscendingRatingAsync()
        {
            var ascendingMovies = await repository.GetMoviesByAscendingRatingAsync();
            
            return ascendingMovies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> GetMoviesPageAsync(int page, int pageEntries)
        {
            var moviesList = await repository.GetMoviesPageListAsync(page, pageEntries);
            
            return moviesList.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> SortByGenreAndRatingAsync()
        {
            var sortedMovies = await repository.SortByGenreAndRatingAsync();

            return sortedMovies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<string>> GetGenresAsync()
        {
            return await repository.GetGenresAsync();
        }

        public async Task<MovieDetailsDto?> GetMovieByIdAsync(int id)
        {
            var foundMovie = await repository.GetByIdAsync(id);

            return (foundMovie is null) ? null : new MovieDetailsDto
            {
                Id = foundMovie.Id,
                Title = foundMovie.Title,
                Genre = foundMovie.Genre,
                AverageRating = foundMovie.AverageRating
            };
        }

        public async Task<MovieDetailsDto?> GetMovieByTitleAsync(string title)
        {
            var foundMovie = await repository.GetByTitleAsync(title);

            return (foundMovie is null) ? null : new MovieDetailsDto
            {
                Id = foundMovie.Id,
                Title = foundMovie.Title,
                Genre = foundMovie.Genre,
                AverageRating = foundMovie.AverageRating
            };
        }

        public async Task<List<GenreStatsDto>> StatusPerGenreAsync()
        {
            var movies = await repository.GetMoviesAsync();

            return movies.GroupBy(m => m.Genre).Select(g => new GenreStatsDto
            {
                Genre = g.Key,
                MovieCount= g.Count(),
                AverageRating = g.Average(m=> m.AverageRating)

            }).ToList();
        }
    }
}
