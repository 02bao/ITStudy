using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoriteController(
    IFavoriteRepository _favoriteRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("FollowTeacher")]
    public IActionResult FollowTeacher([FromQuery] long StudentId, [FromQuery] long TeacherId, [FromBody] Favorite_CreateDTO _DTO )
    {
        var follow = _mapper.Map<Favorite_Create>(_DTO);
        bool IsSuccess = _favoriteRepository.FollowTeacher(StudentId, TeacherId, follow);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpPost("FavoriteCourse")]
    public IActionResult FavoriteCourse([FromQuery] long StudentId, [FromQuery] long CourseId, [FromBody] Favorite_CreateDTO _DTO)
    {
        var follow = _mapper.Map<Favorite_Create>(_DTO);
        bool IsSuccess = _favoriteRepository.FavoriteCourse(StudentId, CourseId, follow);
        return IsSuccess ? Ok() : BadRequest();
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var Instruc = _mapper.Map<List<FavoriteDTO>>(_favoriteRepository.GetAll());
        return Ok(Instruc);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var Instruc = _mapper.Map<FavoriteDTO>(_favoriteRepository.GetById(Id));
        return Ok(Instruc);
    }


    [HttpGet("GetByStudentId")]
    public IActionResult GetByTeacherId([FromQuery] long StudentId)
    {
        var Instruc = _mapper.Map<List<FavoriteDTO>>(_favoriteRepository.GetByStudentId(StudentId));
        return Ok(Instruc);
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _favoriteRepository.Delete(Id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
