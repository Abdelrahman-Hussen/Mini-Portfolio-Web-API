using Portfolio.Common.Objects;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Domain.Features.Products.Dtos.Properties
{
    public class ProductPropertiesRequestModel : RequestModel
    {
        [Required]
        public Guid ProductId { get; set; }
    }
}
