using MoviesWatchListAPI.Repositories;

namespace MoviesWatchListAPI.Services
{
    public class UserMovieService(UserMovieRepository userMovieRepository, MovieRepository movieRepository) : IUserMovieService
    {

    }
}
