using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Domain.Features.ContactSection.Dtos.ContactUsForm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers.ContactSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController(IContactUsService _contactUsService) : ControllerBase
    {
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ContactUsDto>>> Get([FromQuery] RequestModel request)
            => Ok(_contactUsService.Get(request));

        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ContactUsDto>>> GetById(Guid Id)
            => Ok(_contactUsService.GetById(Id));

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ContactUsDto>>> Create([FromBody] CreateContactUsDto Dto)
             => Ok(await _contactUsService.Create(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _contactUsService.Delete(Id));
    }
}
