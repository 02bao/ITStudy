using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VouchersController(
    IVouchersRepository _vouchersRepository,
    IMapper _mapper) : ControllerBase
{

    [HttpPost("CreateNewVouchers")]
    public IActionResult CreateNewVouchers(long TeacherId, long CourseId, DateTime ExpireTime,  [FromBody] Vouchers_AddDTO _DTO)
    {
        var course = _mapper.Map<Vouchers_Add>(_DTO);
        bool IsSuccess = _vouchersRepository.CreateNewVoucher(TeacherId,CourseId , ExpireTime, course);
        return IsSuccess ? Ok(course) : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var Instruc = _mapper.Map<List<VouchersDTO>>(_vouchersRepository.GetAll());
        return Ok(Instruc);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var Instruc = _mapper.Map<VouchersDTO>(_vouchersRepository.GetById(Id));
        return Ok(Instruc);
    }


    [HttpGet("GetByTeacherId")]
    public IActionResult GetByTeacherId([FromQuery] long TeacherId)
    {
        var Instruc = _mapper.Map<List<VouchersDTO>>(_vouchersRepository.GetByTeacherId(TeacherId));
        return Ok(Instruc);
    }


    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _vouchersRepository.Delete(Id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
