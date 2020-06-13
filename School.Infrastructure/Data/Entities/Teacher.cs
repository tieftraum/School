using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace School.Infrastructure.Data.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName => FirstName + LastName;
        public DateTime? DoB { get; set; }
        public DateTime? DoD { get; set; }
    }
}
