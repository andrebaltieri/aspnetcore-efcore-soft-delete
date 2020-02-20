using backoffice.Models;
using Microsoft.EntityFrameworkCore;

namespace backoffice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
                    : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Title);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.Deleted);
        }
    }
}