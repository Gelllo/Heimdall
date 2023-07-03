using Heimdall.Application;
using Microsoft.EntityFrameworkCore;
using Heimdall.Infrastracture;
using Heimdall.Infrastracture.Database;
using Heimdall.Infrastracture.Database.Dispatchers;

namespace Heimdall.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(x =>
                x.UseLazyLoadingProxies()
                    .UseSqlServer(builder.Configuration.GetConnectionString("HeimdallConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return builder;
        }
    }
}
