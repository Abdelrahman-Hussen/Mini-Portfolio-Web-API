using Portfolio.Domain.Features.Auth.Dtos.Password;
using Portfolio.Domain.Features.User.Models;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Application.Validation
{
    internal class ChangePasswordValidation : AbstractValidator<ChangePasswordDto>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ChangePasswordValidation(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(isUserExist)
                .WithMessage(Message.Error_UserEmailNotExist);
        }

        private bool isUserExist(string email)
            => _userManager.Users.Any(x => x.Email == email);
    }
}
