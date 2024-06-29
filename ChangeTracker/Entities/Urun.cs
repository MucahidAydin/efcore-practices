using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTracker.Entities
{
    public class Urun
    {
        // Id, ID, [Entity Name]Id, [Entity Name]ID => Primary Key
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int StokAdedi { get; set; }
    }
}
