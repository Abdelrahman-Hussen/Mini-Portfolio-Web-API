using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.Products
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductExtraDetailsController(IProductExtraDetailsService _productExtraDetailsService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductExtraDetailsDto>>> Get([FromQuery] ProductExtraDetailsRequestModel request)
            => Ok(_productExtraDetailsService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductExtraDetailsDto>>> GetById(Guid Id)
        => Ok(_productExtraDetailsService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ProductExtraDetailsDto>>> Create([FromBody] CreateProductExtraDetailsDto Dto)
        => Ok(await _productExtraDetailsService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<ProductExtraDetailsDto>>> Update([FromBody] UpdateProductExtraDetailsDto Dto)
        => Ok(await _productExtraDetailsService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _productExtraDetailsService.Delete(Id));
    }
}
