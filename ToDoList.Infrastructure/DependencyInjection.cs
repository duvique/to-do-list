using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Domain.Contracts;
using ToDoList.Infrastructure.Classes;
using AppContext = ToDoList.Infrastructure.EF.AppContext.AppContext;

namespace ToDoList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .ConfigureEntityFramework(configuration)
                .AddUnitOfWork();
        }
        internal static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppContext>(options =>
            {
                var sqlServerConnectionString = configuration.GetConnectionString("SqlServer");
                options.UseSqlServer(sqlServerConnectionString);
            });

            return services;
        }
        internal static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork<AppContext>>();
        }
    }
}
