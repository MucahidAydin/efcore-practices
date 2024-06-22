using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Querying.Entities
{
    public class Parca
    {
        public int Id { get; set; }
        public string ParcaAdi { get; set; }

        public ICollection<UrunParca> UrunParcalar { get; set; }
    }
}
