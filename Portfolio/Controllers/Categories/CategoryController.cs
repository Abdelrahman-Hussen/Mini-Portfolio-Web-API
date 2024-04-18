using Portfolio.Application.Features.Categories.Abstractions;
using Portfolio.Domain.Features.Categories.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<CategoryDto>>> Get([FromQuery] RequestModel request)
            => Ok(_categoryService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<CategoryLookUpDto>>> GetAsLookup()
            => Ok(_categoryService.GetAsLookup());

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<CategoryDto>>> GetById(Guid Id)
        => Ok(_categoryService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> Create([FromForm] CreateCategoryDto Dto)
        => Ok(await _categoryService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<CategoryDto>>> Update([FromForm] UpdateCategoryDto Dto)
        => Ok(await _categoryService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _categoryService.Delete(Id));
    }
}
