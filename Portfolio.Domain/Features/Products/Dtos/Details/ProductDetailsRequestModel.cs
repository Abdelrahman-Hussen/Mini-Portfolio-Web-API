using Portfolio.Common.Objects;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Features.Products.Dtos.Details
{
    public class ProductDetailsRequestModel : RequestModel
    {
        [Required]
        public Guid ProductId { get; set; }
    }
}
