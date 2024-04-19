using AutoMapper;
using ITStudy.DTO;
using ITStudy.Interface;
using ITStudy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITStudy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController(
        ICategoryRepository _categoryRepository,
        IMapper _mapper) : ControllerBase
    {
        [HttpPost("CreateNewCategory")]
        public IActionResult CreateNewCategory( [FromBody] Category_CreateDTO _DTO)
        {
            var categories = _mapper.Map<Category_Create>(_DTO);
            bool IsSuccess = _categoryRepository.CreateNew(categories);
            return IsSuccess ? Ok() : BadRequest();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var category = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
            return Ok(category);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(long Id)
        {
            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetById(Id));
            return Ok(category);
        }


    }
}
