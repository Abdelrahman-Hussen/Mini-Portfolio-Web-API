using Portfolio.Common.Objects;

namespace Portfolio.Domain.Features.Products.Dtos.Products
{
    public class ProductRequestModel : RequestModel
    {
        public Guid? CategoryId { get; set; }
        public bool WithIncludes { get; set; } = false;
    }
}
