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
    public class LecturesController(
        ILecturesRepository _lecturesRepository,
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("CreateNewLectures")]
        public IActionResult CreateNewLectures(long CourseId, [FromBody] Lectures_CreateDTO _DTO)
        {
            var course = _mapper.Map<Lectures_Create>(_DTO);
            bool IsSuccess = _lecturesRepository.CreateNew(CourseId , course);
            return IsSuccess ? Ok(course) : BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Instruc = _mapper.Map<List<LecturesDTO>>(_lecturesRepository.GetAll());
            return Ok(Instruc);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long Id)
        {
            var Instruc = _mapper.Map<LecturesDTO>(_lecturesRepository.GetById(Id));
            return Ok(Instruc);
        }

        [HttpGet("GetByCourseID")]
        public IActionResult GetByTeacherId([FromQuery] long CourseId)
        {
            var Instruc = _mapper.Map<List<LecturesDTO>>(_lecturesRepository.GetByCourseId(CourseId));
            return Ok(Instruc);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromForm] LecturesDTO _DTO, [FromForm] List<IFormFile> Images)
        {
            var Course = _mapper.Map<Lectures>(_DTO);
            bool IsSuccess = _lecturesRepository.Update(Course, Images);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
            bool IsSuccess = _lecturesRepository.Delete(Id);
            return IsSuccess ? Ok() : BadRequest();
        }
    }
}
