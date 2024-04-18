using Portfolio.Common.AppSettingsSections;

namespace Portfolio.Extensions
{
    public static class AppSettingExtension
    {
        public static IServiceCollection AddAppSettingSectionsService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<smtp>(configuration.GetSection(nameof(smtp)));
            services.Configure<Token>(configuration.GetSection(nameof(Token)));

            return services;
        }
    }
}
