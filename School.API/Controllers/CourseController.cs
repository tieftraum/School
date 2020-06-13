using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using School.Infrastructure.Data.Entities;
using School.Infrastructure.Dtos;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CourseController(IUnitOfWork unitOfWork, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _mapper = mapper;
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteCourse(int id)
        {
            try
            {
                var course = _unitOfWork.Courses.Get(id);

                if (course==null)
                {
                    return NotFound();
                }
                _unitOfWork.Courses.Remove(course);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPost]
        public IActionResult AddCourse(CourseDto courseDto)
        {
            try
            {
                var uri = _linkGenerator.GetPathByAction("AddCourse", "Course", courseDto.Title);
                var course = _mapper.Map<Course>(courseDto);
                _unitOfWork.Courses.Add(course);
                _unitOfWork.Complete();
                return Ok($"Course {course.Title} added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, CourseDto courseDto)
        {
            try
            {
                if (id!=courseDto.CourseId)
                {
                    return NotFound("Id doesnt match");
                }
                var updatedCourse = _mapper.Map<Course>(courseDto);
                _unitOfWork.Courses.Update(updatedCourse);
                _unitOfWork.Complete();
                return Ok("Course updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
