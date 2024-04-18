using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.Categories.Dtos
{
    public class UpdateCategoryDto
    {
        public Guid Id { get; set; }
        public TranslatableContent? Name { get; set; }
        public TranslatableContent? Description { get; set; }
        public IFormFile? Image { get; set; }
    }
}
