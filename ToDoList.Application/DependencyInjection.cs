using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}
