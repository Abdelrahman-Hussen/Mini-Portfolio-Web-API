using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.AboutSection.Abstractions;
using Portfolio.Domain.Features.AboutSection.Dtos.About;

namespace Portfolio.Controllers.AboutSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController(IAboutUsService _aboutUsService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<AboutUsDto>>> Get()
            => Ok(_aboutUsService.Get());

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<AboutUsDto>>> CreateOrUpdate([FromForm] CreateOrUpdateAboutUsDto Dto)
            => Ok(await _aboutUsService.CreateOrUpdate(Dto));

    }
}
