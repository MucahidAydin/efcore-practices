using EFCoreConfigurations.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConfigurations.Contexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer methodu => Database Provider 
            optionsBuilder.UseSqlServer("Server=localhost;Database=blog_db ;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");

        }
    }
}
