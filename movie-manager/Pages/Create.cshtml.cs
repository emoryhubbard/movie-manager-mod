using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using movie_manager.Data;
using movie_manager.Models;

namespace movie_manager.Pages
{
    public class CreateModel : PageModel
    {
        private readonly movie_manager.Data.movie_managerContext _context;

        public CreateModel(movie_manager.Data.movie_managerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Movie == null || Movie == null)
            {
                return Page();
            }
            Movie.Price = 0m;

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
