using Microsoft.EntityFrameworkCore;
using MoviesWatchListAPI.Models;

namespace MoviesWatchListAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<User> Users => Set<User>();

        public DbSet<UserMovie> UserMovies => Set<UserMovie>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMovie>()
                .HasKey(um => new { um.UserId, um.MovieId });

            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.User)
                .WithMany()
                .HasForeignKey(um => um.UserId);

            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.Movie)
                .WithMany()
                .HasForeignKey(um => um.MovieId);
        }
    }
}
