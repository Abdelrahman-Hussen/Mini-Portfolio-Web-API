using Portfolio.Domain.Features.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class ProductPropertiesConfig : IEntityTypeConfiguration<ProductProperties>
    {
        public void Configure(EntityTypeBuilder<ProductProperties> builder)
        {
            builder
                .OwnsMany(x => x.Name, m => { m.ToJson(); });
        }
    }
}