namespace Portfolio.Domain.Features.Auth.Dtos.Password
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string OTP { get; set; }
        public string NewPassword { get; set; }
    }
}
