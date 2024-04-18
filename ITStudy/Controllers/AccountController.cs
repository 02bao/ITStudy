using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    IUsersRepository _usersRepository,
    IEmailService _emailService,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("Register")]
    public IActionResult Register([FromBody] Users_RegisterDTO _DTO)
    {
        var Account = _mapper.Map<Users_Register>(_DTO);
        string Token = _usersRepository.Regiter(Account);
        if (Token == "") { return BadRequest(); }

        bool emailSent = _emailService.SendRegisterEmail(_DTO.Email, _DTO.UserName, Token);
        if (!emailSent)
        {
            Console.WriteLine("Failed to send registration email to: " + _DTO.Email);
        }

        return emailSent ? Ok() : BadRequest();
    }


    [HttpGet("Verify/{Tokens}")]
    public IActionResult Verify(string Tokens)
    {
        bool IsSuccess = _usersRepository.VerifyUser(Tokens);
        return IsSuccess ? Ok("Verify Successfully") : BadRequest();
    }

    [HttpGet("Reject")]
    public IActionResult Reject(string Tokens)
    {
        bool IsSuccess = _usersRepository.RejectUser(Tokens);
        return IsSuccess ? Ok("Reject Successfully") : BadRequest();
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] Users_Login _DTO)
    {
        var user = _mapper.Map<Users_LoginDTO>(_usersRepository.Login(_DTO));
        if(user == null) { return BadRequest(); }
        return Ok(user);
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var User = _mapper.Map<List<UsersDTO>>(_usersRepository.GetAll());
        return Ok(User);
    }

    [HttpGet("GetById")]
    public IActionResult GetById([FromQuery] long UserId)
    {
        var user = _mapper.Map<UsersDTO>(_usersRepository.GetById(UserId));
        return Ok(user);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromForm] UsersDTO _DTO, [FromForm] List<IFormFile> Images)
    {
        var users = _mapper.Map<Users>(_DTO);
        bool IsSuccess = _usersRepository.Update(users, Images);
        return IsSuccess ? Ok() : BadRequest();
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long id)
    {
        bool IsSuccess = _usersRepository.Delete(id);
        return IsSuccess ? Ok() : BadRequest();
    }

    //[HttpPost("Anh")]
    //public IActionResult Anh(IFormFile anh)
    //{
    //    using (var memoryStream = new MemoryStream())
    //    {
    //        anh.CopyTo(memoryStream);
    //        byte[] imageBytes = memoryStream.ToArray();

    //        // Thay đổi kiểu MIME tùy theo định dạng ảnh của bạn
    //        string contentType = "image/jpeg"; // Đây là ví dụ cho định dạng ảnh JPEG

    //        // Trả về dữ liệu ảnh với kiểu MIME tương ứng
    //        return File(imageBytes, contentType);
    //    }
    //}

}
