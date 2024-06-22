using Microsoft.EntityFrameworkCore;
using Querying.Entities;

namespace Querying.Contexts
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Parca> Parcalar { get; set; }

        public DbSet<UrunParca> UrunParcalar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // UseSqlServer methodu => Database Provider 
            optionsBuilder.UseSqlServer("Server=localhost;Database=ETicaret;User Id=mucahid;Password=test12345;TrustServerCertificate=True;");

            // Provider
            // Connection String
            // Lazy Loading
            // vb.
        }

    }
}
