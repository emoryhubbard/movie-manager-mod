using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using movie_manager.Models;

namespace movie_manager.Data
{
    public class movie_managerContext : DbContext
    {
        public movie_managerContext (DbContextOptions<movie_managerContext> options)
            : base(options)
        {
        }

        public DbSet<movie_manager.Models.Movie> Movie { get; set; } = default!;
    }
}
