
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Init
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseInitializer(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<Init.DataLoader>();
                initializer.Seed(configuration);
            }
        }
    }
}
