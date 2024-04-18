using Portfolio.Domain.Features.User.Models;
using Portfolio.Infrastructure;
using Portfolio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;

namespace Portfolio.Extensions
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
