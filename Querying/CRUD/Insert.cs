
using Querying.Contexts;
using Querying.Entities;


namespace Querying.CRUD
{
    public class Insert
    {

        public async Task InsertData()
        {
            ETicaretContext context = new();

            Urun urun1 = new Urun { UrunAdi = "Bilgisayar", Fiyat = 5000, StokAdedi = 100 };

            List<Parca> parcalar1 = new List<Parca>() {
                                new Parca { ParcaAdi = "Ekran Kartı" },
                                new Parca { ParcaAdi = "Anakart" },
                                new Parca { ParcaAdi = "İşlemci" },
                                new Parca { ParcaAdi = "Ram" },
                                new Parca { ParcaAdi = "SSD" },
                                new Parca { ParcaAdi = "HDD" },
                                new Parca { ParcaAdi = "Kasa" },
                                new Parca { ParcaAdi = "Güç Kaynağı" },
                                new Parca { ParcaAdi = "Soğutucu" },
                                new Parca { ParcaAdi = "Monitör" },
                                new Parca { ParcaAdi = "Klavye" },
                                new Parca { ParcaAdi = "Fare" } };


            await context.Urunler.AddRangeAsync(urun1);
            await context.Parcalar.AddRangeAsync(parcalar1);
            await context.SaveChangesAsync();

            List<UrunParca> urunParcalar = new List<UrunParca>();
            foreach (Parca parca in parcalar1)
            {
                urunParcalar.Add(new UrunParca
                {
                    UrunId = urun1.Id,
                    ParcaId = parca.Id
                });
            }

            await context.UrunParcalar.AddRangeAsync(urunParcalar);
            await context.SaveChangesAsync();

        }
    }
}
