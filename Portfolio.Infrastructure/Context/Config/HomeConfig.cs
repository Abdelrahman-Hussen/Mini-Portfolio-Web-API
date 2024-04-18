using Portfolio.Domain.Features.Categories.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Features.HomeSection.Models;

namespace Portfolio.Infrastructure.Context.Config
{
    internal class HomeConfig : IEntityTypeConfiguration<Home>
    {
        public void Configure(EntityTypeBuilder<Home> builder)
        {
            builder
                .OwnsMany(x => x.Header, m => { m.ToJson(); })
                .OwnsMany(x => x.SubHeader, m => { m.ToJson(); })
                .OwnsMany(x => x.Description, m => { m.ToJson(); });
        }
    }
}