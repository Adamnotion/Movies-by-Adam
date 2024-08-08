using Microsoft.EntityFrameworkCore;
using Movies.Services.MovieAPI.Models;
using System.Net.Sockets;


namespace Movies.Services.MovieAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 1,
                Name = "Inception",
                Description = "A thief who enters the dreams of others to steal secrets from their subconscious.",
                Price = 5.00,
                category = "Sci-Fi",
                ImageUrl = "C:/Users/user/Desktop/assets/Movie assets/inception.jpg"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 2,
                Name = "The Shawshank Redemption",
                Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                Price = 7.00,
                category = "Drama",
                ImageUrl = "https://placehold.co/603x403"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 4,
                Name = "Pulp Fiction",
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                Price = 6.00,
                category = "Crime",
                ImageUrl = "https://placehold.co/603x403"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 5,
                Name = "Forrest Gump",
                Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
                Price = 4.00,
                category = "Drama",
                ImageUrl = "https://placehold.co/603x403"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 6,
                Name = "The Matrix",
                Description = "A computer programmer discovers a dystopian world inside a simulation and joins a rebellion to overthrow the machines that control it.",
                Price = 10.50,
                category = "Sci-Fi",
                ImageUrl = "https://placehold.co/603x403"
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                MovieId = 7,
                Name = "Schindler's List",
                Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                Price = 2.50,
                category = "Drama",
                ImageUrl = "https://placehold.co/603x403"
            });
        }
    }
}