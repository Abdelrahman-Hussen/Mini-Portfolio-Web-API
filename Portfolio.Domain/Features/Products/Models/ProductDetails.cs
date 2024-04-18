using Portfolio.Domain.Features.Products.Dtos.Details;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Features.Products.Models
{
    public class ProductDetails : EntityWithId
    {
        public TranslatableContent Content { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }

        public void Update(UpdateProductDetailsDto dto)
        {
            Content = dto.Content ?? Content;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
