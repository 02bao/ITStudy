using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstructorsRepository(
    IInstructorsRepository _instructorsRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewTeacher")]
    public IActionResult CreateNewTeacher(long UserId, [FromBody] Instructors_CreateDTO _DTO)
    {
        var teacher = _mapper.Map<Instructors_Create>(_DTO);
        bool IsSuccess = _instructorsRepository.CreateNew(UserId, teacher);
        return IsSuccess ? Ok(teacher) : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var Instruc = _mapper.Map<List<InstructorsDTO>>(_instructorsRepository.GetAll());
        return Ok(Instruc);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var Instruc = _mapper.Map<InstructorsDTO>(_instructorsRepository.GetById(Id));
        return Ok(Instruc);
    }


    [HttpGet("GetByUserId")]
    public IActionResult GetByUserId([FromQuery] long UserId)
    {
        var Instruc = _mapper.Map<List<InstructorsDTO>>(_instructorsRepository.GetByUserId(UserId));
        return Ok(Instruc);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] InstructorsDTO _DTO,[FromForm] List<IFormFile> Images)
    {
        var Teacher = _mapper.Map<Instructors>(_DTO);
        bool IsSuccess = _instructorsRepository.Update(Teacher, Images);
        return IsSuccess ? Ok(): BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _instructorsRepository.Delete(Id);
        return IsSuccess ? Ok(): BadRequest();
    }

}
