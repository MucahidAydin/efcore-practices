using EFCoreCRUD.CRUD;

Insert insert1 = new Insert(Ad: "Kalem", Fiyat: 10, Stok: 200);
int urunId = insert1.InsertData().Result;// async metot olduğu için Result ile beklenir.
Console.WriteLine($"Eklenen ürün Id: {urunId}");