using Microsoft.Extensions.DependencyInjection;
using Portfolio.Common.Abstractions;
using Portfolio.Common.Provider;

namespace Portfolio.Common.DI
{
    public static class Bootstrap
    {
        public static IServiceCollection AddCommonStrapping(this IServiceCollection services)
        {

            services.AddScoped<IMailProvider, MailProvider>();

            return services;
        }
    }
}
