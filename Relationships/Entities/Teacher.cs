using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Office Office { get; set; }
        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }

    }
}
