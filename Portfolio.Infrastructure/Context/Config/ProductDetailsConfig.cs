using Portfolio.Domain.Features.Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class ProductDetailsConfig : IEntityTypeConfiguration<ProductDetails>
    {
        public void Configure(EntityTypeBuilder<ProductDetails> builder)
        {
            builder
                .OwnsMany(x => x.Content, m => { m.ToJson(); });
        }
    }
}