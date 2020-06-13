using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Data.Entities
{
    public class SchoolClass
    {
        public SchoolClass()
        {
            Students = new HashSet<Student>();
        }
        public int SchoolClassId { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
