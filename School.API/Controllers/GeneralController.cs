using Microsoft.AspNetCore.Mvc;
using School.Infrastructure.Repositories;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using School.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;
using School.Infrastructure.Dtos;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private readonly IGeneralRepository _repository;
        private readonly IMapper _mapper;

        public GeneralController(IGeneralRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("courses")]
        public async Task<ActionResult<IList<CourseDto>>> GetCourses()
        {
            try
            {
                var result = await _repository.GetCoursesAsync();

                if (result == null) return NotFound("Not Found");

                return _mapper.Map<List<CourseDto>>(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("classes")]
        public async Task<ActionResult<IList<SchoolClassDto>>> GetClasses()
        {
            try
            {
                var result = await _repository.GetClassesAsync();

                if (result == null) return NotFound();

                return _mapper.Map<List<SchoolClassDto>>(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
