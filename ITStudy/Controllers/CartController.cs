using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(
        ICartRepository _cartRepository,
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("AddtoCart")]
        public IActionResult AddtoCart(long StudentId, [FromBody] CartItem_AddDTO _DTO )
        {
            var cart = _mapper.Map<CartItem_Add>(_DTO);
            bool IsSuccess = _cartRepository.AddtoCart(StudentId, cart);
            return  IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet("GetByUserId")]
        public IActionResult GetByStudentId( long UserId)
        {
            var carts = _cartRepository.GetByUserId(UserId);
            return Ok(carts);
        }
    }
}
