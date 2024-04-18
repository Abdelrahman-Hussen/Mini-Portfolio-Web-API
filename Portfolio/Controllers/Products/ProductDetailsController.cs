using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Domain.Features.Products.Dtos.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.Products
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController(IProductDetailsService _productDetailsService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductDetailsDto>>> Get([FromQuery] ProductDetailsRequestModel request)
            => Ok(_productDetailsService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductDetailsDto>>> GetById(Guid Id)
        => Ok(_productDetailsService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ProductDetailsDto>>> Create([FromBody] CreateProductDetailsDto Dto)
        => Ok(await _productDetailsService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<ProductDetailsDto>>> Update([FromBody] UpdateProductDetailsDto Dto)
        => Ok(await _productDetailsService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _productDetailsService.Delete(Id));
    }
}
