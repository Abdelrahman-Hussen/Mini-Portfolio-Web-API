using Portfolio.Domain.Features.Auth.Dtos.Password;

namespace Portfolio.Application.Features.Auth
{
    public interface IPasswordService
    {
        Task<ResponseModel<string>> ChangePassword(ChangePasswordDto model);
        Task<ResponseModel<string>> ResetPassword(ResetPasswordDto model);
    }
}