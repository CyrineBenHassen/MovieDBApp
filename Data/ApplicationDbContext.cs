using Microsoft.EntityFrameworkCore;
using TP3.Models;



namespace TP3.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembreshipType> MembreshipTypes { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }



    }

   
}




