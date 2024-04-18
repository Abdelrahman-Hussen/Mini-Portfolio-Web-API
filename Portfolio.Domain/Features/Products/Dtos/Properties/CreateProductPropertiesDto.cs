using Portfolio.Domain.Features.Products.Enums;

namespace Portfolio.Domain.Features.Products.Dtos.Properties
{
    public class CreateProductPropertiesDto
    {
        public TranslatableContent Name { get; set; }
        public string Value { get; set; }
        public ProductPropertyType Type { get; set; }
        public Guid ProductId { get; set; }
    }
}
