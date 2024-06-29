
using Microsoft.EntityFrameworkCore;
using Querying.Contexts;
using Querying.CRUD;
using Querying.Entities;


////Data Insert
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


//---

//#14
//ETicaretContext context = new();
//// where
//Console.WriteLine("--- Where ---");
//var urunler = await context.Urunler.Where(u => u.Fiyat > 5000).ToListAsync();

//Console.WriteLine($"Fiyatı 5000'den büyük olan ürünler: {urunler.Count}");


//// OrderBy
//Console.WriteLine("--- OrderBy ---");
//var urunler2 = await context.Urunler.Where(u => u.Fiyat > 5000).OrderBy(u => u.Fiyat).Take(5).ToListAsync();

//foreach (var urun in urunler2)
//{
//    Console.WriteLine($"Urun adi: {urun.UrunAdi}, Fiyat: {urun.Fiyat}, Stok: {urun.StokAdedi}");
//}


//// ThenBy
//Console.WriteLine("--- ThenBy ---");
//var urunler3 = await context.Urunler.OrderBy(u => u.Fiyat).ThenByDescending(u => u.StokAdedi).Take(10).ToListAsync();

//foreach (var urun in urunler3)
//{
//    Console.WriteLine($"Urun adi: {urun.UrunAdi}, Fiyat: {urun.Fiyat}, Stok: {urun.StokAdedi}");
//}

//// Query Syntax
//Console.WriteLine("--- Query Syntax ---");
//var urunler4 = await (from u in context.Urunler
//                      where u.Fiyat > 5000
//                      orderby u.Fiyat descending
//                      select u).Take(5).ToListAsync();


//---

//#15
//ETicaretContext context = new();

////// Single, SingleOrDefault
//var urun1 = await context.Urunler.SingleAsync(u => u.Id == 60000000);
//Console.WriteLine(urun1.UrunAdi);

//var urun2 = await context.Urunler.SingleOrDefaultAsync(u => u.Id == 60000000);
//Console.WriteLine(urun2?.UrunAdi);

//// Single ile First arasındaki fark: Single tek bir kayıt döner, First ise bir veya daha fazla kayıt olsa da sadece ilk kaydı döner.

////// First,FirstOrDefault
//var urun3 = await context.Urunler.FirstAsync(u => u.Id > 5);
//Console.WriteLine(urun3.UrunAdi);

//var urun4 = await context.Urunler.FirstOrDefaultAsync(u => u.Id == 60000000);
//Console.WriteLine(urun4?.UrunAdi);

////// Find, Composite Key => Sadece primary key ile calisir
//var urun5 = await context.Urunler.FindAsync(5);
//Console.WriteLine(urun5?.UrunAdi);

//var urunParca1 = await context.UrunParcalar.FindAsync(urun5?.Id, 303);
//Console.WriteLine($"{urunParca1?.UrunId} - {urunParca1?.ParcaId}");

//////LastOrDefault
//var urun6 = await context.Urunler.OrderBy(u => u.Id).LastOrDefaultAsync();
//Console.WriteLine(urun6?.UrunAdi);


////#16
//ETicaretContext context = new();

////toListAsync() kullanmayan sorgular => CountAsync, AnyAsync, MaxAsync, MinAsync, AllAsync, SumAsync, AverageAsync
//var urunCount = await context.Urunler.CountAsync(); // int tipinde doner.
//Console.WriteLine($"Toplam urun sayisi: {urunCount}");

//var urunCount2 = await context.Urunler.LongCountAsync(); // long tipinde doner.
//Console.WriteLine($"Toplam urun sayisi: {urunCount2}");

//var urunCheck = await context.Urunler.Where(u => u.UrunAdi.Contains("B")).AnyAsync();// where sorgusu sonucunda bir kayit varsa true doner.
//Console.WriteLine($"Urun adinda 'B' harfi olan urun var mi: {urunCheck}");

//var urunMax = await context.Urunler.MaxAsync(u => u.Fiyat);
//Console.WriteLine($"En yuksek fiyat: {urunMax}");

//var urunMin = await context.Urunler.MinAsync(u => u.Fiyat);
//Console.WriteLine($"En dusuk fiyat: {urunMin}");

//var urunler = await context.Urunler.AllAsync(u => u.Fiyat > 0);// Tum urunlerin fiyati 0'dan buyuk mu? true/false doner.
//Console.WriteLine($"Tum urunlerin fiyati 0'dan buyuk mu: {urunler}");

//var toplamFiyat = await context.Urunler.SumAsync(u => u.Fiyat);// Fiyat sutunundaki degerlerin toplamini doner.
//Console.WriteLine($"Toplam fiyat: {toplamFiyat}");

//var ortalamaFiyat = await context.Urunler.AverageAsync(u => u.Fiyat);// Fiyat sutunundaki degerlerin ortalamasini doner.
//Console.WriteLine($"Ortalama fiyat: {ortalamaFiyat}");

////toListAsync() kullanan sorgular => Distinct, StartsWith, EndsWith, Contains
//var UrunAdlari = await context.Urunler.Select(u => u.UrunAdi).Distinct().ToListAsync();// UrunAdi sutunundaki degerlerden tekrar edenleri cikarir.
//foreach (var UrunAdi in UrunAdlari)
//{
//    Console.WriteLine(UrunAdi);
//}

//var urunler2 = await context.Urunler.Where(u => u.UrunAdi.StartsWith("B")).ToListAsync();// UrunAdi sutununda 'B' ile baslayan urunleri getirir.
//foreach (var urun in urunler2)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

//var urunler3 = await context.Urunler.Where(u => u.UrunAdi.EndsWith("r")).ToListAsync();// UrunAdi sutununda 'r' ile biten urunleri getirir.
//foreach (var urun in urunler3)
//{
//    Console.WriteLine(urun.UrunAdi);
//}

//var urunler4 = await context.Urunler.Where(u => u.UrunAdi.Contains("B")).ToListAsync();// UrunAdi sutununda 'B' harfi gecen urunleri getirir.
//foreach (var urun in urunler4)
//{
//    Console.WriteLine(urun.UrunAdi);
//}


////#17
//ETicaretContext context = new();

//var urunler = await context.Urunler.ToDictionaryAsync(u => u.Id, u => u.UrunAdi);// Urunler tablosundaki Id ve UrunAdi sutunlarini dictionary tipinde doner.

//foreach (var urun in urunler)
//{
//    //[9996, Urun-ceff2522-c5f7-4fbc-a09f-87566e5c4fb7]
//    Console.WriteLine(urun);
//}

//var urunler2 = await context.Urunler.ToArrayAsync();// Urunler Dbset'te belirtilen entity tipinde verileri döner. örn: [Urun, Urun, Urun, ...]
//foreach (var urun in urunler2)
//{
//    Console.WriteLine($"{urun.UrunAdi} - {urun.Fiyat}");
//}

//var urunler3 = await context.Urunler.Select(u => new { u.UrunAdi, u.Fiyat }).ToArrayAsync();// Urunler tablosundan sadece UrunAdi ve Fiyat sutunlarini doner.
//foreach (var urun in urunler3)
//{
//    Console.WriteLine($"{urun.UrunAdi} - {urun.Fiyat}");
//}



//var urunler4 = await context.Urunler.Include(u => u.UrunParcalar).SelectMany(u => u.UrunParcalar, (u, urunparca) => new { u.UrunAdi, urunparca.ParcaId }).ToArrayAsync();// Urunler tablosundan UrunAdi ve UrunParcalar tablosundan ParcaId sutunlarini doner. many to many iliskiyi OnModelCreating metodunda tanimladik.
//foreach (var urun in urunler4)
//{
//    Console.WriteLine(urun);
//}

////SelectMany alternatif
//var urunler5 = await (from u in context.Urunler
//                      from up in u.UrunParcalar
//                      select new
//                      {
//                          u.UrunAdi,
//                          up.ParcaId
//                      }).ToArrayAsync();
//foreach (var urun in urunler5)
//{
//    Console.WriteLine(urun);
//}


//18
ETicaretContext context = new();

//Method Syntax
var datas = await context.Urunler.GroupBy(u => u.UrunAdi).Select(g => new { UrunAdi = g.Key, ToplamFiyat = g.Sum(u => u.Fiyat) }).ToListAsync();// Urunler tablosundaki UrunAdi sutununa gore gruplar ve her grup icin Fiyat sutunundaki degerlerin toplamini doner.
foreach (var data in datas)
{
    Console.WriteLine($"{data.UrunAdi} - {data.ToplamFiyat}");
}

//Query Syntax
var datas2 = await (from u in context.Urunler
                    group u by u.UrunAdi into g
                    select new
                    {
                        UrunAdi = g.Key,
                        ToplamFiyat = g.Sum(u => u.Fiyat)
                    }).ToListAsync();

//foreach alternatif
datas2.ForEach(data => {
    Console.WriteLine($"{data.UrunAdi} - {data.ToplamFiyat}");
});