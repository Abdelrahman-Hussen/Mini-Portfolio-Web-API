﻿using Portfolio.Application.Features.Auth;
using Portfolio.Domain.Features.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthService _authService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<AuthDto>>> Login([FromBody] LoginDto Dto)
            => Ok(await _authService.Login(Dto));

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<AuthDto>>> Register([FromBody] RegisterDto Dto)
             => Ok(await _authService.Register(Dto));

    }
}
