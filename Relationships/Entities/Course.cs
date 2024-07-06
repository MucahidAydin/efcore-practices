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
        public string CourseName { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
        public List<StudentCourse> Students { get; set; }
    }
}
