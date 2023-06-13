using Heimdall.Application;
using Heimdall.Infrastracture.Database.Dispatchers;
using Heimdall.Infrastracture.Database;
using Microsoft.EntityFrameworkCore;

namespace Heimdall.Web.Configuration
{
    public static class DatabaseConfiguration
    {
        public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("HeimdallConnection")));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return builder;
        }
    }
}
