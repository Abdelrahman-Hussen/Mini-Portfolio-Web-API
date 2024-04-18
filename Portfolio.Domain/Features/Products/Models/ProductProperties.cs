using Portfolio.Domain.Features.Products.Dtos.Properties;
using Portfolio.Domain.Features.Products.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Domain.Features.Products.Models
{
    public class ProductProperties : EntityWithId
    {
        public TranslatableContent Name { get; set; }
        public string Value { get; set; }
        public ProductPropertyType Type { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Guid ProductId { get; set; }

        public void Update(UpdateProductPropertiesDto dto)
        {
            Name = dto.Name ?? Name;
            Value = dto.Value ?? Value;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
