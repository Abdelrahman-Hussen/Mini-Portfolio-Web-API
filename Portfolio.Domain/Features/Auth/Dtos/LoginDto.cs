namespace Portfolio.Domain.Features.Auth
{
    public record LoginDto
    {
        public string Email { get; init; }
        public string Password { get; init; }
        public string? RefreshToken { get; init; }
    }
}
