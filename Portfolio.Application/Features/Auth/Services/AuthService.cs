using Portfolio.Domain.Features.Auth;
using Portfolio.Domain.Features.User.Dtos;
using Portfolio.Domain.Features.User.Models;

using Microsoft.AspNetCore.Identity;

namespace Portfolio.Application.Features.Auth
{
    internal class AuthService(UserManager<ApplicationUser> _userManager,
                               IValidator<LoginDto> _loginValidation,
                               IValidator<RegisterDto> _registerValidation,
                               IJwtTokenService _jwtTokenService,
                               IRefreshTokenService _refreshTokenService,
                               IMapper _mapper) : IAuthService
    {
        public async Task<ResponseModel<AuthDto>> Login(LoginDto loginDto)
        {
            var validationResult = await _loginValidation.ValidateAsync(loginDto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            if (!string.IsNullOrEmpty(loginDto.RefreshToken))
                await _refreshTokenService.RevokeToken(loginDto.RefreshToken);

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            var jwtToken = _jwtTokenService.CreateJwtToken(user);

            var newRefreshToken = await _refreshTokenService.GenerateRefreshToken(user.Id);

            var authDto = new AuthDto(jwtToken, newRefreshToken,
                _mapper.Map<ApplicationUserDto>(user));

            return ResponseModel<AuthDto>.Success(authDto);
        }

        public async Task<ResponseModel<AuthDto>> Register(RegisterDto registerDto)
        {

            var validationResult = await _registerValidation.ValidateAsync(registerDto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            var user = _mapper.Map<ApplicationUser>(registerDto);

            var createResult = await _userManager.CreateAsync(user, registerDto.Password);

            if (!createResult.Succeeded)
                throw new BadRequestException(ValidationHelper.ArrangeIdentityErrors(createResult.Errors));

            var jwtToken = _jwtTokenService.CreateJwtToken(user);

            var refreshToken = await _refreshTokenService.GenerateRefreshToken(user.Id);

            var authDto = new AuthDto(jwtToken, refreshToken,
                    _mapper.Map<ApplicationUserDto>(user));

            return ResponseModel<AuthDto>.Success(authDto);
        }
    }
}
