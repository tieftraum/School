using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
        public int ClassId { get; set; }
    }
}
