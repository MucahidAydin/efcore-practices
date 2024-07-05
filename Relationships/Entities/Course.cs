using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }
        public int OgretmenId { get; set; }

        public List<StudentCourse> students { get; set; }

    }
}
