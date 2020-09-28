using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieLibrary_WebAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(): base("MLApi")
        {

        }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

    }
}