using EFCoreCRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCRUD.Contexts
{
    public class ETicaretContext : DbContext // Class ismi Context ile bitmeli
    {
        public DbSet<Urun> Urunler { get; set; }
        // Urunler => Veritabanıdaki tablo adı olacak.
        
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
