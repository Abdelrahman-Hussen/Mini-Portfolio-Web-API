using Portfolio.Application.Features.Auth;
using Portfolio.Domain.Features.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RefreshTokenController(IRefreshTokenService _refreshTokenService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<AuthDto>>> RefreshToken(string token)
            => Ok(await _refreshTokenService.RefreshToken(token));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> RevokeToken(string token)
            => Ok(await _refreshTokenService.RevokeToken(token));
    }
}
