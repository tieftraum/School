using System;
using System.Collections;
using System.Collections.Generic;

namespace School.Infrastructure.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
        public int ClassId { get; set; }
        public SchoolClass Class { get; set; }
    }
}
