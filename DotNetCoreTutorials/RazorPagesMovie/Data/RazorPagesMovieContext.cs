namespace RazorPagesMovie.Data
{
    using Microsoft.EntityFrameworkCore;

    using RazorPagesMovie.Models;

    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}