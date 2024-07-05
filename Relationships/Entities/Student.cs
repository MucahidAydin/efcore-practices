using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Isim { get; set; }

        public List<StudentCourse> Coruses { get; set; }
    }
}
