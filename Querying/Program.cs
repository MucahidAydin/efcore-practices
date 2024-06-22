
using Microsoft.EntityFrameworkCore;
using Querying.Contexts;
using Querying.CRUD;
using Querying.Entities;


// Data Insert
//for (int i = 0; i < 10000; i++)
//{
//    Insert insert = new();
//    await insert.InsertData();
//    Console.WriteLine($"{i + 1}. veri eklendi.");
//}



// #13
//ETicaretContext context = new();
//Urun? urun = await context.Urunler.FirstOrDefaultAsync(u => u.UrunAdi == "Bilgisayar");
//Console.WriteLine($"Urun adi: {urun?.UrunAdi}, Fiyat: {urun?.Fiyat}, Stok: {urun?.StokAdedi}");



//#14
ETicaretContext context = new();
// where
Console.WriteLine("--- Where ---");
var urunler = await context.Urunler.Where(u => u.Fiyat > 5000).ToListAsync();

Console.WriteLine($"Fiyatı 5000'den büyük olan ürünler: {urunler.Count}");


// OrderBy
Console.WriteLine("--- OrderBy ---");
var urunler2 = await context.Urunler.Where(u => u.Fiyat > 5000).OrderBy(u => u.Fiyat).Take(5).ToListAsync();

foreach (var urun in urunler2)
{
    Console.WriteLine($"Urun adi: {urun.UrunAdi}, Fiyat: {urun.Fiyat}, Stok: {urun.StokAdedi}");
}


// ThenBy
Console.WriteLine("--- ThenBy ---");
var urunler3 = await context.Urunler.OrderBy(u => u.Fiyat).ThenByDescending(u => u.StokAdedi).Take(10).ToListAsync();

foreach (var urun in urunler3)
{
    Console.WriteLine($"Urun adi: {urun.UrunAdi}, Fiyat: {urun.Fiyat}, Stok: {urun.StokAdedi}");
}

// Query Syntax
Console.WriteLine("--- Query Syntax ---");
var urunler4 = await (from u in context.Urunler
                      where u.Fiyat > 5000
                      orderby u.Fiyat descending
                      select u).Take(5).ToListAsync();