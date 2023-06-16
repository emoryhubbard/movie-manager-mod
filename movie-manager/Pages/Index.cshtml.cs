using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movie_manager.Data;
using movie_manager.Models;

namespace movie_manager.Pages {
    public class IndexModel : PageModel {
        private readonly movie_manager.Data.movie_managerContext _context;

        public IndexModel(movie_manager.Data.movie_managerContext context) {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Ratings { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieRating { get; set; }
        public SelectList? SortColumns { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortColumn { get; set; }
        public async Task OnGetAsync() {
            // Use LINQ to get list of genres.
            IQueryable<string> ratingQuery = from m in _context.Movie
                                             orderby m.Rating
                                             select m.Rating;

            var movies = from m in _context.Movie
                         orderby m.Rating
                         select m;

            if (!string.IsNullOrEmpty(SortColumn)) {
                movies = from m in _context.Movie
                         orderby m.ReleaseDate
                         select m;
            }

            if (!string.IsNullOrEmpty(SearchString)) {
                movies = (IOrderedQueryable<Movie>) movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieRating)) {
                movies = (IOrderedQueryable<Movie>) movies.Where(x => x.Rating == MovieRating);
            }
            Ratings = new SelectList(await ratingQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
