using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(
    IStudentRepository _studentRepository,
    IMapper _mapper) : ControllerBase
{

    [HttpPost("CreateNewStudents")]
    public IActionResult CreateNewStudents(long UserId, [FromBody] Student_CreateDTO _DTO)
    {
        var course = _mapper.Map<Student_Create>(_DTO);
        bool IsSuccess = _studentRepository.CreateNew(UserId, course);
        return IsSuccess ? Ok(course) : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var Instruc = _mapper.Map<List<StudentDTO>>(_studentRepository.GetAll());
        return Ok(Instruc);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var Instruc = _mapper.Map<StudentDTO>(_studentRepository.GetById(Id));
        return Ok(Instruc);
    }


    [HttpGet("GetByUserId")]
    public IActionResult GetByTeacherId([FromQuery] long UserId)
    {
        var Instruc = _mapper.Map<List<StudentDTO>>(_studentRepository.GetByUserId(UserId));
        return Ok(Instruc);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] StudentDTO _DTO)
    {
        var Course = _mapper.Map<Student>(_DTO);
        bool IsSuccess = _studentRepository.Update(Course);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _studentRepository.Delete(Id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
