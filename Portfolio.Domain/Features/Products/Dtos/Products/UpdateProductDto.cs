using Microsoft.AspNetCore.Http;

namespace Portfolio.Domain.Features.Products.Dtos.Products
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public TranslatableContent? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Barcode { get; set; }
        public List<IFormFile>? Images { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
