using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Heimdall.Web.Configuration
{
    public static class SecurityConfiguration
    {
        public static IServiceCollection ConfigureSecurity(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddCookie(x =>
                {
                    x.Cookie.Name = "token";
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApplicationSettings:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    x.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["X-Access-Token"];
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                    builder.WithOrigins("https://localhost:4200", "http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
            });

            return services;
        }
    }
}
