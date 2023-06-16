using Microsoft.EntityFrameworkCore;
using movie_manager.Data;

namespace movie_manager.Models;

public static class SeedData {
    public static void Initialize(IServiceProvider serviceProvider) {
        using (var context = new movie_managerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<movie_managerContext>>())) {
            if (context == null || context.Movie == null) {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Movie.Any()) {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie {
                    Title = "What angers God above all else.",
                    ReleaseDate = DateTime.Parse("2023-6-12"),
                    Genre = "Alma 7:23",
                    Price = 7.99M,
                    Rating = "Alma"
                },

                new Movie {
                    Title = "Revelation comes from hunger.",
                    ReleaseDate = DateTime.Parse("2023-6-02"),
                    Genre = "Alma 5:46",
                    Price = 8.99M,
                    Rating = "Alma"
                },

                new Movie {
                    Title = "Humility leads to salvation.",
                    ReleaseDate = DateTime.Parse("2023-5-25"),
                    Genre = "Mosiah 29:20",
                    Price = 9.99M,
                    Rating = "Mos."
                },

                new Movie {
                    Title = "Sincere repentance is key.",
                    ReleaseDate = DateTime.Parse("2023-5-19"),
                    Genre = "Mosiah 28:4",
                    Price = 3.99M,
                    Rating = "Mos."
                }
            );
            context.SaveChanges();
        }
    }
}