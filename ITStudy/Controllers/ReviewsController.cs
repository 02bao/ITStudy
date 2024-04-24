using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using ITStudy.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController(
        IReviewsRepository _reviewsRepository,
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("CreateNewReviews")]
        public IActionResult CreateNewReviews(long StudentId, long CartItemIds, [FromBody] Reviews_CreateDTO _DTO)
        {
            var course = _mapper.Map<Reviews_Create>(_DTO);
            bool IsSuccess = _reviewsRepository.CreateNewReview(StudentId, CartItemIds, course);
            return IsSuccess ? Ok(course) : BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Instruc = _mapper.Map<List<ReviewsDTO>>(_reviewsRepository.GetAll());
            return Ok(Instruc);
        }

        [HttpGet("GetByStudentId")]
        public IActionResult GetByStudnetId([FromQuery] long StudentId)
        {
            var Instruc = _mapper.Map<List<ReviewsDTO>>(_reviewsRepository.GetByStudentId(StudentId));
            return Ok(Instruc);
        }

        [HttpGet("GetByTeacherId")]
        public IActionResult GetByTeacherId([FromQuery] long TeacherId)
        {
            var Instruc = _mapper.Map<List<ReviewsDTO>>(_reviewsRepository.GetByTeacherId(TeacherId));
            return Ok(Instruc);
        }

       
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ReviewsDTO _DTO)
        {
            var Course = _mapper.Map<Reviews>(_DTO);
            bool IsSuccess = _reviewsRepository.Update(Course);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(long Id)
        {
            bool IsSuccess = _reviewsRepository.Delete(Id);
            return IsSuccess ? Ok() : BadRequest();
        }
    }
}
