using AccountService.Service;
using CoreService.Behaviours;
using CoreService.Bus;
using CoreService.Events;
using CoreService.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>>(x => x.GetService<IDomainNotificationHandler>());
            services.AddScoped<IEventStore, InMemoryEventStore>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CommandValidationBehaviours<,>));
            services.AddScoped<IAccountsService, AccountsService>();
            return services;
        }
    }
}
