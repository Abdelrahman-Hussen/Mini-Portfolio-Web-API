using Portfolio.Domain.Features.Auth;
using Portfolio.Domain.Features.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Application.Validation
{
    internal class LoginValidation : AbstractValidator<LoginDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginValidation(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            RuleFor(u => new { u.Email, u.Password })
               .NotEmpty()
               .MustAsync((a, cancellationToken) => isEmailExist(a.Email, a.Password, cancellationToken))
               .WithMessage(Message.Error_Login);
        }
        private async Task<bool> isEmailExist(string email, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return !(user == null || (!await _userManager.CheckPasswordAsync(user, password)));
        }
    }
}
