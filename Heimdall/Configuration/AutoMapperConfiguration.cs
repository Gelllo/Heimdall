using Heimdall.Application.Mappings;
using System.Reflection;

namespace Heimdall.Web.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        { 
            services.AddAutoMapper(Assembly.GetAssembly(typeof(GlucoseRecordMappings)));

            return services;
        }
    }
}
