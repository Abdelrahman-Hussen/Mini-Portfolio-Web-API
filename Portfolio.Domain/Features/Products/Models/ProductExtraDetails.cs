using Portfolio.Domain.Features.Products.Dtos.ExtraDetails;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Features.Products.Models
{
    public class ProductExtraDetails : EntityWithId
    {
        public TranslatableContent Title { get; set; }
        public TranslatableContent Description { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }
        public void Update(UpdateProductExtraDetailsDto dto)
        {
            Title = dto.Title ?? Title;
            Description = dto.Description ?? Description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
