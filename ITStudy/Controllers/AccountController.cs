﻿using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
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
        return IsSuccess ? Ok() : BadRequest();
    }
}
