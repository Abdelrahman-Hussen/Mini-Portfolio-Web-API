using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Domain.Features.Products.Dtos.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.Products
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _productService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductDto>>> Get([FromQuery] ProductRequestModel request)
            => Ok(_productService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductDto>>> GetById(Guid Id)
        => Ok(_productService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ProductDto>>> Create([FromForm] CreateProductDto Dto)
        => Ok(await _productService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<ProductDto>>> Update([FromForm] UpdateProductDto Dto)
        => Ok(await _productService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _productService.Delete(Id));
    }
}
