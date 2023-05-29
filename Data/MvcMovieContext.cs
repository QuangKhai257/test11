using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TEST1.Models;
using Test11.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<TEST1.Models.student> student { get; set; } = default!;

        public DbSet<Test11.Models.Employee> Employee { get; set; } = default!;
    }
}
