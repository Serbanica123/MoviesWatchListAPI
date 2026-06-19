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
            var movies = await repository.GetMoviesByDescendingRatingAsync();
            return movies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> GetMoviesByAscendingRatingAsync()
        {
            var movies = await repository.GetMoviesByAscendingRatingAsync();
            return movies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> GetMoviesPageAsync(int page, int pageEntries)
        {
            var movies = await repository.GetMoviesPageListAsync(page, pageEntries);
            return movies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<MovieDetailsDto>> SortByGenreAndRatingAsync()
        {
            var movies = await repository.SortByGenreAndRatingAsync();
            return movies.Select(movie => new MovieDetailsDto
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
            var movie = await repository.GetByIdAsync(id);
            return (movie is null) ? null : new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            };
        }

        public async Task<MovieDetailsDto?> GetMovieByTitleAsync(string title)
        {
            var movie = await repository.GetByTitleAsync(title);
            return (movie is null) ? null : new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            };
        }

        public async Task<List<GenreStatsDto>> StatusPerGenreAsync()
        {
            var movies = await repository.GetMoviesAsync();

            return movies
                .GroupBy(m => m.Genre)
                .Select(g => new GenreStatsDto
                {
                    Genre = g.Key,
                    MovieCount = g.Count(),
                    AverageRating = g.Average(m => m.AverageRating)
                })
                .ToList();
        }

        public async Task<List<MovieDetailsDto>> FilterMoviesAsync(string? genre, float? minRating, float? maxRating)
        {
            var filteredMovies = await repository.FilterMoviesAsync(genre, minRating, maxRating);

            return filteredMovies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }
    }
}
