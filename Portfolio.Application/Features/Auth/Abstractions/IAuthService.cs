using Portfolio.Domain.Features.Auth;

namespace Portfolio.Application.Features.Auth
{
    public interface IAuthService
    {
        Task<ResponseModel<AuthDto>> Login(LoginDto loginDto);
        Task<ResponseModel<AuthDto>> Register(RegisterDto registerDto);
    }
}