using Portfolio.Domain.Features.Products.Enums;

namespace Portfolio.Domain.Features.Products.Dtos.Properties
{
    public class ProductPropertiesDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public ProductPropertyType Type { get; set; }
    }
}
