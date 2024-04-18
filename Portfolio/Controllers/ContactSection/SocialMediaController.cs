using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Domain.Features.ContactSection.Dtos.SocailMeadias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.ContactSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController(ISocialMediaService _socialMediaService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<SocialMediaDto>>> Get()
            => Ok(_socialMediaService.Get());

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<SocialMediaDto>>> CreateOrUpdate([FromBody] CreateOrUpdateSocialMediaDto Dto)
            => Ok(await _socialMediaService.CreateOrUpdate(Dto));
    }
}
