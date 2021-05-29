using AccountService.DataAcces.Repository;
using AccountService.Domain;
using CoreService.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.DataAccess.EF
{
    public static class EFInstaller
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>("UseInMemoryDatabase");
            var connectionString = "Server=sql,1433;Database=MicroService;User Id=SA;Password=P@SSword!@#123;";
            // services.AddDbContext<AccountDbContext>();
            services.AddDbContext<AccountDbContext>(options =>
            {
                if (useInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("MicroService");
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor,ActionContextAccessor>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            // services.AddScoped<DbContext, AccountDbContext>();
            
            return services;
        }
    }
}
