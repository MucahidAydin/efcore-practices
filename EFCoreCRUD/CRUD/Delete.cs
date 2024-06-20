using EFCoreCRUD.Contexts;
using EFCoreCRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCRUD.CRUD
{
    public class Delete
    {
        private int Id { get; set; }
        public Delete(int Id)
        {
            this.Id = Id;
        }

        public void DeleteData()
        {
            ETicaretContext context = new ETicaretContext();
            Urun? urun = context.Urunler.FirstOrDefault(u => u.Id == Id);

            context.Urunler.Remove(urun);
            context.SaveChanges();
        }
    }
}
