
using Microsoft.EntityFrameworkCore;
using Tracking.Contexts;

ETicaretContext context = new();


var urunler = context.Urunler.AsNoTracking().ToList();//Change Tracker'ı kapattık.
urunler.ForEach(urunler =>
{
    Console.WriteLine(urunler.UrunAdi);
});


var datas = context.Urunler.Include(u => u.UrunParcalar).SelectMany(u => u.UrunParcalar, (u, urunparca) => new { u.UrunAdi, urunparca.ParcaId }).AsNoTrackingWithIdentityResolution().ToArrayAsync(); //Change Tracker'ı kısmi kapattık.
foreach (var data in datas.Result)
{
    Console.WriteLine(data.UrunAdi + " " + data.ParcaId);
}
