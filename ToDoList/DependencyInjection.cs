namespace ToDoList.API
{
    public static class DependencyInjection
    {
        private static readonly string _corsPolicyAllowAll = "_allowAllOrigins";

        internal static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: _corsPolicyAllowAll,
                    policy =>
                    {
                        policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                    });
            });

            return services;
        }

        internal static WebApplication UseCorsAllowAll(this WebApplication app)
        {
            app.UseCors(_corsPolicyAllowAll);

            return app;
        }
    }
}
