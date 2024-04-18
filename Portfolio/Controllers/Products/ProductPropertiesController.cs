using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Domain.Features.Products.Dtos.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.Products
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertiesController(IProductPropertiesService _productPropertiesService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductPropertiesDto>>> Get([FromQuery] ProductPropertiesRequestModel request)
            => Ok(_productPropertiesService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ProductPropertiesDto>>> GetById(Guid Id)
        => Ok(_productPropertiesService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ProductPropertiesDto>>> Create([FromBody] CreateProductPropertiesDto Dto)
        => Ok(await _productPropertiesService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<ProductPropertiesDto>>> Update([FromBody] UpdateProductPropertiesDto Dto)
        => Ok(await _productPropertiesService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _productPropertiesService.Delete(Id));
    }
}
