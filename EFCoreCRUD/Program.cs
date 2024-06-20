using EFCoreCRUD.CRUD;
using EFCoreCRUD.Entities;

//Insert
Insert insert1 = new Insert(Ad: "Kalem", Fiyat: 10, Stok: 200);
int urunId = insert1.InsertData().Result;// async metot olduğu için Result ile beklenir.
Console.WriteLine($"Eklenen ürün Id: {urunId}");

//Sleep 10sn
Thread.Sleep(10000);

//Update
Update update1 = new Update(Id: urunId, Ad: "Kalem", Fiyat: 15, Stok: 150);
Urun urunUpdate = update1.UpdateData().Result;
Console.WriteLine($"Güncellenen ürün: {urunUpdate.Id} - {urunUpdate.Ad} - {urunUpdate.Fiyat} - {urunUpdate.Stok}");