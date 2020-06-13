using School.Infrastructure.Data.Entities;
using School.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);
    }
}
