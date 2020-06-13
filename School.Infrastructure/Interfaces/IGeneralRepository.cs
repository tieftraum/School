using School.Infrastructure.Data.Entities;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Interfaces
{
    public interface IGeneralRepository 
    {
        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<IEnumerable<SchoolClass>> GetClassesAsync();

    }
}
