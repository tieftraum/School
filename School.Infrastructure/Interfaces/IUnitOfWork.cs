using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        int Complete();
    }
}
