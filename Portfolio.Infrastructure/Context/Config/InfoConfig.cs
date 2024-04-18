using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Domain.Features.AboutSection.Models;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class InfoConfig : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder
                .OwnsMany(x => x.Title, m => { m.ToJson(); })
                .OwnsMany(x => x.Slogan, m => { m.ToJson(); });
        }
    }
}