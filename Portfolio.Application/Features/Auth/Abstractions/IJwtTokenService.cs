using Portfolio.Domain.Features.User.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Portfolio.Application.Features.Auth
{
    public interface IJwtTokenService
    {
        JwtSecurityToken CreateJwtToken(ApplicationUser user);
    }
}