using Portfolio.Domain.Features.Auth.Dtos.OTP;

namespace Portfolio.Application.Features.General
{
    public interface IOTPService
    {
        Task<ResponseModel<string>> ConfirmMailOTP(ConfirmMailOTPDto confirmMailOTPDto);
        Task<ResponseModel<string>> SendOTPViaMail(SendMailOTPDto sendOTPDto);
    }
}