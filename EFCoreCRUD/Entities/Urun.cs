using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCRUD.Entities
{
    public class Urun // Tekil İsimlendirme
    {
        // Id, ID, [Entity Name]Id, [Entity Name]ID => Primary Key
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
        public int Stok { get; set; }
    }
}
