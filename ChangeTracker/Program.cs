
using ChangeTracker.Contexts;
using Microsoft.EntityFrameworkCore;

ETicaretContext context = new();

var urun = await
    context.Urunler.FirstOrDefaultAsync(u => u.Id == 48);

//Unchanged
Console.WriteLine(context.Entry(urun).State);

urun.UrunAdi = "Bilgisayar";
//Modified
Console.WriteLine(context.Entry(urun).State);


//Değişiklik var
context.ChangeTracker.DetectChanges();

var _urun = await context.Entry(urun).GetDatabaseValuesAsync();
if (urun.UrunAdi == _urun.GetValue<string>("UrunAdi"))
{
    Console.WriteLine("Değişiklik yok");
}
else
{
    Console.WriteLine("Değişiklik var");
}

await context.SaveChangesAsync(false); context.ChangeTracker.DetectChanges();
//Modified
Console.WriteLine(context.Entry(urun).State);

context.ChangeTracker.AcceptAllChanges();
//Unchanged
Console.WriteLine(context.Entry(urun).State);

