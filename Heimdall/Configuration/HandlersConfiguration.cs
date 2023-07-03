using System.Reflection;
using Heimdall.Application;
using Heimdall.Infrastracture;
using Heimdall.Infrastracture.Database;

namespace Heimdall.Web.Configuration
{
    public static class HandlersConfiguration
    {
        public static IServiceCollection ConfigureHandlers(this IServiceCollection services)
        {
            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            services.Scan(selector =>
            {
                selector.FromAssemblyDependencies(Assembly.GetAssembly(typeof(DataContext)))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(Heimdall.Application.ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            return services;
        }
    }
}
