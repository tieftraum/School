using School.Infrastructure.Data;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;
        public UnitOfWork(SchoolContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Students = new StudentRepository(_context);
            Teachers = new TeacherRepository(_context);
        }
        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ITeacherRepository Teachers { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
