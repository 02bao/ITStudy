using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
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
}
