using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController(
    IPostRepository _postRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewPosts")]
    public IActionResult CreateNewPosts(long TeacherId, [FromBody] Posts_CreateDTO _DTO)
    {
        var post = _mapper.Map<Posts_Create>(_DTO);
        bool IsSuccess = _postRepository.CreateNewPosts(TeacherId, post);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var post = _mapper.Map<List<PostsDTO>>(_postRepository.GetAll());
        return Ok(post);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long Id)
    {
        var post = _mapper.Map<PostsDTO>(_postRepository.GetById(Id));
        return Ok(post);
    }


    [HttpGet("GetByTeacherId")]
    public IActionResult GetByUserId([FromQuery] long TeacherId)
    {
        var Instruc = _mapper.Map<List<PostsDTO>>(_postRepository.GetByTeacherId(TeacherId));
        return Ok(Instruc);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] PostsDTO _DTO, [FromForm] List<IFormFile> Images)
    {
        var Post = _mapper.Map<Posts>(_DTO);
        bool IsSuccess = _postRepository.Update(Post, Images);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long Id)
    {
        bool IsSuccess = _postRepository.Delete(Id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
