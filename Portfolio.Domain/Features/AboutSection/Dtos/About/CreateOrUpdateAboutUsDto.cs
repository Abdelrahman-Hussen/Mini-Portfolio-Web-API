using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.AboutSection.Dtos.About
{
    public class CreateOrUpdateAboutUsDto
    {
        public TranslatableContent? Header { get; set; }
        public TranslatableContent? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
