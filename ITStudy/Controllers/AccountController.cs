using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(
    IUsersRepository _usersRepository,
    IMapper _mapper) : ControllerBase
{
    [HttpPost("Register")]
    public IActionResult Register([FromBody] Users_RegisterDTO _DTO)
    {
        var Account = _mapper.Map<Users_Register>(_DTO);
        bool IsSuccess = _usersRepository.Regiter(Account);
        if (IsSuccess)
        {
            bool emailSent = SendRegisterEmail(_DTO.Email, _DTO.UserName);
            if (!emailSent)
            {
                Console.WriteLine("Failed to send registration email to: " + _DTO.Email);
            }
        }

        return IsSuccess ? Ok() : BadRequest();
    }
    private bool SendRegisterEmail(string ReceiveEmails, string ReceiveName)
    {
        try
        {
            var Emails = new EmailService();
            string Subject = "Đăng kí tài khoản thành công";
            string Body = "Chào mừng bạn đã đăng kí tài khoản thành công.";
            return Emails.SendEmail(ReceiveEmails, ReceiveName,Subject, Body);
        }
        catch(Exception ex)
        {
            return false;
        }
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

    [HttpDelete("Delete")]
    public IActionResult  Delete(long  id)
    {
        bool IsSuccess = _usersRepository.Delete(id);
        return IsSuccess ? Ok() : BadRequest();
    }


}
