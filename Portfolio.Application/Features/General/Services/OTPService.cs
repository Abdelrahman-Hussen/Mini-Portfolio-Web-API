using Portfolio.Application.Features.System;
using Portfolio.Common.Abstractions;
using Portfolio.Domain.Features.Auth.Dtos.OTP;
using Portfolio.Domain.Features.Auth.Models;

namespace Portfolio.Application.Features.General.Services
{
    internal class OTPService(IGenericRepository<OTP> _otpRepo,
                              IValidator<ConfirmMailOTPDto> _confirmOTPValidation,
                              IMailProvider _mailHelper) : IOTPService
    {
        public async Task<ResponseModel<string>> SendOTPViaMail(SendMailOTPDto sendOTPDto)
        {

            var emailOtp = _otpRepo.GetEntityWithSpec(OTPSpecification.GetByEmail(sendOTPDto.Email));

            string otp = new Random().Next(1000, 9999).ToString();

            if (emailOtp == null)
            {
                OTP emailOTP = new()
                {
                    Email = sendOTPDto.Email,
                    OTPCode = otp,
                    OTPExpirationDate = DateTime.Now.AddMinutes(5)
                };

                await _otpRepo.Add(emailOTP);
                await _otpRepo.Save();

                await _mailHelper.Send(emailOTP.Email, "Mail Verification",
                    $"Verification OTP {emailOTP.OTPCode}\nValid until {emailOTP.OTPExpirationDate}");

                return ResponseModel<string>.Success();
            }
            else
            {
                emailOtp.OTPCode = otp;
                emailOtp.OTPExpirationDate = DateTime.Now.AddMinutes(5);

                //_otpRepo.Update(emailOtp);        // need to test
                await _otpRepo.Save();

                await _mailHelper.Send(emailOtp.Email, "Mail Verification",
                $"Verification OTP {emailOtp.OTPCode}\nValid until {emailOtp.OTPExpirationDate}");

                return ResponseModel<string>.Success();
            }
        }

        public async Task<ResponseModel<string>> ConfirmMailOTP(ConfirmMailOTPDto confirmMailOTPDto)
        {
            var validationResult = await _confirmOTPValidation.ValidateAsync(confirmMailOTPDto);

            if (!validationResult.IsValid)
                throw new BadRequestException(ValidationHelper.ArrangeValidationErrors(validationResult.Errors));

            return ResponseModel<string>.Success();
        }
    }
}
