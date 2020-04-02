namespace RazorPagesMovie.Models
{
    using System;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using RazorPagesMovie.Data;

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            bool mustSaveChanges = false;

            using RazorPagesMovieContext context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>());

            if (context.Movie.Count(_ => _.Title.Equals("When Harry Met Sally")) == 0)
            {
                context.Movie.Add(new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M
                });
                mustSaveChanges = true;
            }

            if (context.Movie.Count(_ => _.Title.Equals("Ghostbusters")) == 0)
            {
                context.Movie.Add(new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M
                });
                mustSaveChanges = true;
            }

            if (context.Movie.Count(_ => _.Title.Equals("Ghostbusters 2")) == 0)
            {
                context.Movie.Add(new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                });
                mustSaveChanges = true;
            }

            if (context.Movie.Count(_ => _.Title.Equals("Rio Bravo")) == 0)
            {
                context.Movie.Add(new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                });
                mustSaveChanges = true;
            }

            if (mustSaveChanges)
            {
                context.SaveChanges();
            }
        }
    }
}