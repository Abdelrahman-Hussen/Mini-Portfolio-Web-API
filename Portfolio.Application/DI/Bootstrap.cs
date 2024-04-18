using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Features.AboutSection.Abstractions;
using Portfolio.Application.Features.AboutSection.Services;
using Portfolio.Application.Features.Auth;
using Portfolio.Application.Features.Categories.Abstractions;
using Portfolio.Application.Features.Categories.Services;
using Portfolio.Application.Features.ContactSection.Abstractions;
using Portfolio.Application.Features.ContactSection.Services;
using Portfolio.Application.Features.General;
using Portfolio.Application.Features.General.Services;
using Portfolio.Application.Features.HomeSection.Abstractions;
using Portfolio.Application.Features.HomeSection.Services;
using Portfolio.Application.Features.Products.Abstractions;
using Portfolio.Application.Features.Products.Services;
using Portfolio.Application.Features.ReviewsSection.Abstractions;
using Portfolio.Application.Features.ReviewsSection.Services;
using System.Reflection;

namespace Portfolio.Application.DI
{
    public static class Bootstrap
    {
        public static IServiceCollection AddApplicationStrapping(this IServiceCollection services)
        {

            #region Services

            //  System // 
            services.AddScoped<IOTPService, OTPService>();

            // Auth // 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            // Review // 
            services.AddScoped<IReviewService, ReviewService>();

            // Home // 
            services.AddScoped<IHomeService, HomeService>();

            // Category //
            services.AddScoped<ICategoryService, CategoryService>();

            // About //
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IInfoService, InfoService>();

            // Contact //
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IContactInfoService, ContactInfoService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();

            // Products //
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailsService, ProductDetailsService>();
            services.AddScoped<IProductExtraDetailsService, ProductExtraDetailsService>();
            services.AddScoped<IProductPropertiesService, ProductPropertiesService>();

            #endregion

            #region Validators

            services.AddValidatorsFromAssembly(
                    Assembly.GetExecutingAssembly(),
                    includeInternalTypes: true);

            #endregion

            #region Mappster

            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);

            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Flexible);

            services.AddScoped<IMapper, ServiceMapper>();

            #endregion

            return services;
        }
    }
}
