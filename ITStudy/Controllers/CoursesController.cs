using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController(
        ICoursesRepository _coursesRepository,
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("CreateNewCourses")]
        public IActionResult CreateNewCourses(long TeacherId, long CategoryId, [FromBody] Courses_CreateDTO _DTO)
        {
            var course = _mapper.Map<Courses_Create>(_DTO);
            bool IsSuccess = _coursesRepository.CreateNew(TeacherId,CategoryId,course);
            return IsSuccess ? Ok(course) : BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Instruc = _mapper.Map<List<Courses>>(_coursesRepository.GetAll());
            return Ok(Instruc);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long Id)
        {
            var Instruc = _mapper.Map<CoursesDTO>(_coursesRepository.GetById(Id));
            return Ok(Instruc);
        }


        [HttpGet("GetByTeacherId")]
        public IActionResult GetByTeacherId([FromQuery] long TeacherId)
        {
            var Instruc = _mapper.Map<List<CoursesDTO>>(_coursesRepository.GetByTeacherId(TeacherId));
            return Ok(Instruc);
        }

        [HttpGet("GetByCategoryId")]
        public IActionResult GetByCategoryId([FromQuery] long CatgoryId)
        {
            var Instruc = _mapper.Map<List<CoursesDTO>>(_coursesRepository.GetByCategoryId(CatgoryId));
            return Ok(Instruc);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] CoursesDTO _DTO, [FromForm] List<IFormFile> Images)
        {
            var Course = _mapper.Map<Courses>(_DTO);
            bool IsSuccess = _coursesRepository.Update(Course, Images);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
            bool IsSuccess = _coursesRepository.Delete(Id);
            return IsSuccess ? Ok() : BadRequest();
        }
    }
}
