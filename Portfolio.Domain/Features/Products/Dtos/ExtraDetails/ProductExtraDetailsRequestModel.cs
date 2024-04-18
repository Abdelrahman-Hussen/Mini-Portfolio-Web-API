using Portfolio.Common.Objects;

namespace Portfolio.Domain.Features.Products.Dtos.ExtraDetails
{
    public class ProductExtraDetailsRequestModel : RequestModel
    {
        public Guid ProductId { get; set; }
    }
}
