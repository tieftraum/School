using School.Infrastructure.Data;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext context) : base(context)
        {

        }
    }
}
