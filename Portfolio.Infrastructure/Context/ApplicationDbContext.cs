using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Features.AboutSection.Models;
using Portfolio.Domain.Features.Auth.Models;
using Portfolio.Domain.Features.Categories.Models;
using Portfolio.Domain.Features.ContactSection.Models;
using Portfolio.Domain.Features.HomeSection.Models;
using Portfolio.Domain.Features.Products.Models;
using Portfolio.Domain.Features.ReviewsSection.Models;
using Portfolio.Domain.Features.User.Models;
using System.Reflection;

namespace Portfolio.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<OTP> OTP { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ContactInfo> ContactInfo { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<ProductExtraDetails> ProductExtraDetails { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}
