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

//Sleep 10sn    
Thread.Sleep(10000);

//Delete
Delete delete1 = new Delete(Id: urunId);
delete1.DeleteData();
Console.WriteLine($"Silinen ürün Id: {urunId}");

