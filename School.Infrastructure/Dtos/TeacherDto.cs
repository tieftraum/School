using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Dtos
{
    public class TeacherDto
    {
        public int TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
    }
}
