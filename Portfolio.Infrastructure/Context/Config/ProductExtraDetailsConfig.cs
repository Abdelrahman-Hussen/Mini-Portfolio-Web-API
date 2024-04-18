using Portfolio.Domain.Features.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class ProductExtraDetailsConfig : IEntityTypeConfiguration<ProductExtraDetails>
    {
        public void Configure(EntityTypeBuilder<ProductExtraDetails> builder)
        {
            builder
                .OwnsMany(x => x.Title, m => { m.ToJson(); })
                .OwnsMany(x => x.Description, m => { m.ToJson(); });
        }
    }
}