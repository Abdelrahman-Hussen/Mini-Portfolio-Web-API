using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class AboutUsConfig : IEntityTypeConfiguration<AboutUs>
    {
        public void Configure(EntityTypeBuilder<AboutUs> builder)
        {
            builder
                .OwnsMany(x => x.Header, m => { m.ToJson(); })
                .OwnsMany(x => x.Description, m => { m.ToJson(); });
        }
    }
}