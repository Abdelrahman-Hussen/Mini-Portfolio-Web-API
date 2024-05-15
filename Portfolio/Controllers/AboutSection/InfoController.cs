using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.AboutSection.Abstractions;
using Portfolio.Domain.Features.AboutSection.Dtos.Infos;

namespace Portfolio.Controllers.AboutSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController(IInfoService _infoService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<InfoDto>>> Get()
            => Ok(_infoService.Get());

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<InfoDto>>> CreateOrUpdate([FromBody] CreateOrUpdateInfoDto Dto)
            => Ok(await _infoService.CreateOrUpdate(Dto));

    }
}
