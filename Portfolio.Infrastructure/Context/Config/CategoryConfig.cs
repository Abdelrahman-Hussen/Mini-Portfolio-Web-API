using Portfolio.Domain.Features.Categories.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .OwnsMany(x => x.Name, m => { m.ToJson(); })
                .OwnsMany(x => x.Description, m => { m.ToJson(); });
        }
    }
}