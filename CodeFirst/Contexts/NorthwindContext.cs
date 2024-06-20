using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Contexts
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=NorthwindNew;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
        }

    }
}