using Portfolio.Domain.Features.Categories.Dtos;
using Portfolio.Domain.Features.Products.Dtos.Details;
using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using Portfolio.Domain.Features.Products.Dtos.Properties;

namespace Portfolio.Domain.Features.Products.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public List<string> Images { get; set; }
        public CategoryDto Category { get; set; }
        public List<ProductDetailsDto> Details { get; set; }
        public List<ProductExtraDetailsDto> ExtraDetails { get; set; }
        public List<ProductPropertiesDto> Properties { get; set; }
    }
}
