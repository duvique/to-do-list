using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services
                .ConfigureMediatR();
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
