﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relationships.Entities
{
    public class StudentCourse // many to many
    {
        public int OgrenciId { get; set; }
        public int DersId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
