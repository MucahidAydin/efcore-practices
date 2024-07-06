using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Entities
{
    public class Office
    {
        public int Id { get; set; }
        public int Number { get; set; }

        public Teacher Teacher { get; set; }
    }
}
