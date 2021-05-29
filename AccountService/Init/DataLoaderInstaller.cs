using Microsoft.Extensions.DependencyInjection;


namespace AccountService.Init
{
    public static class DataLoaderInstaller
    {
        public static IServiceCollection AddAccountDemoInitializer(this IServiceCollection services)
        {
            services.AddScoped<DataLoader>();
            return services;
        }
    }
}
