using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracking.Entities;

namespace Tracking.Contexts
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

            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); //ChangeTracker QueryTrackingBehavior.NoTracking
            //// -> context.Urunler.AsTracking().ToList(); // ChangeTracker'ı manuel olarak çalıştırma.

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // many to many iliski icin composite key tanimlamasi
            modelBuilder.Entity<UrunParca>().HasKey(up => new { up.UrunId, up.ParcaId });
        }

    }
}
