using School.Infrastructure.Data;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Repositories
{
    class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolContext context):base(context)
        {

        }
    }
}
