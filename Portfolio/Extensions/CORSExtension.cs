namespace Portfolio.Extensions
{
    public static class CORSExtension
    {
        public static IServiceCollection EnableCORSServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .Build();
                });
            });

            return services;
        }
    }
}
