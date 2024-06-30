using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class UrunParca
    {
        public int UrunId { get; set; }
        public Urun Urun { get; set; }

        public int ParcaId { get; set; }
        public Parca Parca { get; set; }
    }
}
