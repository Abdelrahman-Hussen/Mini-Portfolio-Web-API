using Portfolio.Application.Features.Auth;
using Portfolio.Application.Features.General;
using Portfolio.Domain.Features.Auth.Dtos.OTP;
using Portfolio.Domain.Features.Auth.Dtos.Password;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController(IPasswordService _passwordService,
                                    IOTPService _otpService) : ControllerBase
    {
        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> ChangePassword([FromBody] ChangePasswordDto Dto)
            => Ok(await _passwordService.ChangePassword(Dto));

        [AllowAnonymous]
        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> ResetPassword([FromBody] ResetPasswordDto Dto)
            => Ok(await _passwordService.ResetPassword(Dto));

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> SendOtp([FromBody] SendMailOTPDto Dto)
            => Ok(await _otpService.SendOTPViaMail(Dto));
    }
}
