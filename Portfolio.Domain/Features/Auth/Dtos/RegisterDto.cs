namespace Portfolio.Domain.Features.Auth
{
    public record RegisterDto
    {
        public string FullName { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Password { get; init; }
    }
}
