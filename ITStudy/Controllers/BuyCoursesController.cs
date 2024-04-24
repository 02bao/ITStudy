using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BuyCoursesController(
    IBuycoursesRepository _buycoursesRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("BuyNewcourses")]
    public IActionResult BuyNewcourses([FromQuery] long StudentId, [FromQuery] List<long> CartItemIds, long VoucherId)
    {
        bool IsSuccess = _buycoursesRepository.BuyNewcourses(StudentId,CartItemIds, VoucherId);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetByStudentId")]
    public IActionResult GetByStudentId([FromQuery] long StudentId )
    {
        var BuyCourse = _mapper.Map<List<BuyCourses_GetDTO>>(_buycoursesRepository.GetBySutdentId(StudentId));
        return Ok(BuyCourse);
    }

    [HttpGet("GetByTeacherId")]
    public IActionResult GetByTeacherId([FromQuery] long TeacherId)
    {
        var BuyCourse = _mapper.Map<List<BuyCourses_GetDTO>>(_buycoursesRepository.GetBySutdentId(TeacherId));
        return Ok(BuyCourse);
    }
}
