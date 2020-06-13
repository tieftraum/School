using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Infrastructure.Mappings
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Grades, GradesDto>().ReverseMap();
            CreateMap<SchoolClass, SchoolClassDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
        }
    }
}
