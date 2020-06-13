using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Data;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly SchoolContext _schoolContext;
        public GeneralRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public async Task<IEnumerable<SchoolClass>> GetClassesAsync()
        {
            var classes = _schoolContext.SchoolClasses.OrderBy(e=>e.SchoolClassId).ToListAsync();
            return await classes;
        }
        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            var courses = _schoolContext.Courses.ToListAsync();
            return await courses;
        }
    }
}
