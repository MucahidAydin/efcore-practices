using Microsoft.EntityFrameworkCore;
using Relationships.Entities;

namespace Relationships.Contexts
{
    public class UniversityContext: DbContext
    {
        public DbSet<Course>  courses { get; set; }
        public DbSet<Department> depertmants { get; set; }
        public DbSet<Office> offices { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer methodu => Database Provider 
            optionsBuilder.UseSqlServer("Server=localhost;Database=UniversityDB;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
