
using Microsoft.EntityFrameworkCore;
using Querying.Contexts;
using Querying.CRUD;
using Querying.Entities;


Insert insert = new();
await insert.InsertData();


ETicaretContext context = new();

Urun? urun = await context.Urunler.FirstOrDefaultAsync(u => u.UrunAdi == "Bilgisayar");

Console.WriteLine($"Urun adi: {urun?.UrunAdi}, Fiyat: {urun?.Fiyat}, Stok: {urun?.StokAdedi}");