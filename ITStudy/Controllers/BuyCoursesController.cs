using AutoMapper;
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
}
