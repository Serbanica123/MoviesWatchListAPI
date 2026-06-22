using MoviesWatchListAPI.Dtos;
using MoviesWatchListAPI.Models;
using MoviesWatchListAPI.Repositories;

namespace MoviesWatchListAPI.Services
{
    public class UserMovieService(IUserMovieRepository userMovieRepository, IMovieRepository movieRepository) : IUserMovieService
    {
        public async Task<float> RatingsAverageAsync(int id, float? currentRating)
        {
            var ratings = await userMovieRepository.GetMovieRatingsByIdAsync(id);
            return ratings.Any() ? ratings.Average() : currentRating ?? 0.0f;
        }

        public async Task<UserMovieDetailsDto?> AddUserMovieAsync(int userId, UserMoviePostDto userMovie)
        {
            var existingMovie = await movieRepository.GetByTitleAsync(userMovie.Title);

            if (existingMovie is null)
            {
                existingMovie = new Movie
                {
                    Title = userMovie.Title,
                    Genre = userMovie.Genre
                };

                await movieRepository.AddAsync(existingMovie);
                await movieRepository.SaveChangesAsync();
            }

            var movieId = existingMovie.Id;

            var existingEntry = await userMovieRepository.GetByUserAndMovieAsync(userId, movieId);
            if (existingEntry is not null)
                return await UpdateUserMovieAsync(userId, userMovie.Title, new UserMovieUpdateDto
                {
                    Watched = userMovie.Watched,
                    Rating = userMovie.Rating
                });

            var addedMovie = new UserMovie
            {
                UserId = userId,
                MovieId = movieId,
                Watched = userMovie.Watched,
                Rating = userMovie.Rating,
                AddedOn = DateTime.UtcNow
            };

            await userMovieRepository.AddAsync(addedMovie);
            await userMovieRepository.SaveChangesAsync();

            existingMovie.AverageRating = await RatingsAverageAsync(movieId, userMovie.Rating);
            movieRepository.Update(existingMovie);
            await movieRepository.SaveChangesAsync();

            return new UserMovieDetailsDto
            {
                UserId = addedMovie.UserId,
                MovieId = addedMovie.MovieId,
                Watched = addedMovie.Watched,
                Rating = addedMovie.Rating,
                AddedOn = addedMovie.AddedOn
            };
        }

        public async Task<UserMovieDetailsDto?> UpdateUserMovieAsync(int userId, string movieTitle, UserMovieUpdateDto userMovie)
        {
            var movieId = await movieRepository.GetIdByTitleAsync(movieTitle);
            if (movieId is null)
                return null;

            var userMovieEntry = await userMovieRepository.GetByUserAndMovieAsync(userId, movieId.Value);
            if (userMovieEntry is null)
                return null;

            userMovieEntry.Watched = userMovie.Watched;
            userMovieEntry.Rating = userMovie.Rating;

            userMovieRepository.Update(userMovieEntry);
            await userMovieRepository.SaveChangesAsync();

            var existingMovie = await movieRepository.GetByIdAsync(movieId.Value);
            existingMovie!.AverageRating = await RatingsAverageAsync(movieId.Value, userMovie.Rating);

            movieRepository.Update(existingMovie);
            await movieRepository.SaveChangesAsync();

            return new UserMovieDetailsDto
            {
                UserId = userMovieEntry.UserId,
                MovieId = userMovieEntry.MovieId,
                Watched = userMovieEntry.Watched,
                Rating = userMovieEntry.Rating,
                AddedOn = userMovieEntry.AddedOn
            };
        }

        public async Task<List<MovieDetailsDto>> GetUserWatchedMoviesAsync(int userId)
        {
            var movies = await userMovieRepository.GetWatchedMoviesByUserAsync(userId);

            return movies.Select(movie => new MovieDetailsDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                AverageRating = movie.AverageRating
            }).ToList();
        }

        public async Task<List<UserRatingStatsDto>> GetTopRatersAsync()
        {
            return await userMovieRepository.GetTopRatersAsync();
        }
    }
}
