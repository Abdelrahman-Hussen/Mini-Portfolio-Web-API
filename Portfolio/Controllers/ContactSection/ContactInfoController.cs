using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Domain.Features.ContactSection.Dtos.ContactInfos;

namespace Portfolio.Controllers.ContactSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController(IContactInfoService _contactInfoService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ContactInfoDto>>> Get()
            => Ok(_contactInfoService.Get());

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ContactInfoDto>>> CreateOrUpdate([FromBody] CreateOrUpdateContactInfoDto Dto)
            => Ok(await _contactInfoService.CreateOrUpdate(Dto));
    }
}

