using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace Portfolio.Extensions
{
    public static class LocalizationExtension
    {
        public static IServiceCollection AddLocalizationService(this IServiceCollection services)
        {
            services.AddLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new()
                {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    new CultureInfo("ar"),
                    new CultureInfo("ar-EG")
                };

                options.DefaultRequestCulture = new RequestCulture("en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            return services;
        }
    }
}
