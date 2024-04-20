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

        [HttpGet("GetByStudentId")]
        public IActionResult GetByStudentId( long UserId)
        {
            var carts = _cartRepository.GetByStudentId(UserId);
            return Ok(carts);
        }
        [HttpDelete("RemoveCartItem")]
        public IActionResult RemoveCartItem(long CartItemId)
        {
            bool IsSuccess = _cartRepository.RemoveCartItem(CartItemId);
            return IsSuccess? Ok() : BadRequest();
        }
    }
}
