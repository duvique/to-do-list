using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.DomainEventsMediatR;
using ToDoList.Domain.Contracts;

namespace ToDoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services
                .ConfigureMediatR()
                .ConfigureMediatRNotificationWrapper();
        }

        internal static IServiceCollection ConfigureMediatRNotificationWrapper(this IServiceCollection services)
        {
            return services.AddTransient<IDomainEventPublisher, DomainEventPublisher>();
        }
        internal static IServiceCollection ConfigureMediatR(this IServiceCollection services)
        {
            return services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
        }
    }
}
