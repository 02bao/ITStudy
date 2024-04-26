using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController(
    IFavoriteRepository _favoriteRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("FollowTeacher")]
    public IActionResult FollowTeacher([FromQuery] long StudentId, [FromQuery] long TeacherId, [FromBody] Favorite_TeacherDTO _DTO )
    {
        var follow = _mapper.Map<Favorite_Teacher>(_DTO);
        bool IsSuccess = _favoriteRepository.FollowTeacher(StudentId, TeacherId, follow);
        return IsSuccess ? Ok() : BadRequest();
    }
}
