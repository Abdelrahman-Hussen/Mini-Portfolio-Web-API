using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.HomeSection.Abstractions;
using Portfolio.Domain.Features.HomeSection.Dtos;

namespace Portfolio.Controllers.HomeSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController(IHomeService _homeService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<HomeDto>>> Get()
            => Ok(_homeService.Get());

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<HomeDto>>> CreateOrUpdate([FromForm] CreateOrUpdateHomeDto Dto)
            => Ok(await _homeService.CreateOrUpdate(Dto));
    }
}
