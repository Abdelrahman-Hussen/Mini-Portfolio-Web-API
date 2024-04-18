using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.HomeSection.Dtos
{
    public class CreateOrUpdateHomeDto
    {
        public TranslatableContent? Header { get; set; }
        public TranslatableContent? SubHeader { get; set; }
        public TranslatableContent? Description { get; set; }
        public IFormFile? Video { get; set; }
    }
}
