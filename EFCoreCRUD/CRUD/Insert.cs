using EFCoreCRUD.Contexts;
using EFCoreCRUD.Entities;

namespace EFCoreCRUD.CRUD
{
    public class Insert
    {
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }


        public Insert(string Ad, decimal Fiyat, int Stok)
        {
            this.Ad = Ad;
            this.Fiyat = Fiyat;
            this.Stok = Stok;
        }

        public async Task<int> InsertData()
        {
            ETicaretContext context = new ETicaretContext();
            Urun urun = new Urun
            {
                Ad = this.Ad,
                Fiyat = this.Fiyat,
                Stok = this.Stok


            };

            await context.Urunler.AddAsync(urun);
            context.SaveChanges();

            return urun.Id;

        }
    }
}
