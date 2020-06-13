using School.Infrastructure.Data;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Dtos;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course> , ICourseRepository
    {
        public CourseRepository(SchoolContext context): base(context)
        {

        }

        public SchoolContext SchoolContext { get { return SchoolContext; } }

        public void Update(Course course)
        {
            SchoolContext.Courses.Update(course);
        }
    }
}
