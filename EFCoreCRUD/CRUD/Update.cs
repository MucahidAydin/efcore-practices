using EFCoreCRUD.Contexts;
using EFCoreCRUD.Entities;
using Microsoft.EntityFrameworkCore;


namespace EFCoreCRUD.CRUD
{
    public class Update
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
        public Update(int Id, string Ad, decimal Fiyat, int Stok)
        {
            this.Id = Id;
            this.Ad = Ad;
            this.Fiyat = Fiyat;
            this.Stok = Stok;

        }

        public async Task<Urun?> UpdateData()
        {
            ETicaretContext context = new ETicaretContext();
            Urun urun = await context.Urunler.FirstOrDefaultAsync(u => u.Id == Id);
            //FirstOrDefaultAsync metodu ile Id'ye göre ürün yoksa null döner.

            urun.Ad = this.Ad;
            urun.Fiyat = this.Fiyat;
            urun.Stok = this.Stok;
            await context.SaveChangesAsync();

            return urun;
        }


    }
}
