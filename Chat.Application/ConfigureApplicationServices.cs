using Chat.Application.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // DI for AppDefaults settings
        services.AddOptions();

        services.Configure<AppDefaults>(configuration.GetSection("AppDefaults"));

        // To support minimal APIS, only for /api/v1/error 
        services.AddEndpointsApiExplorer();

        // Automapper declaration
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // Add CORS support
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                policyBuilder => policyBuilder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        return services;
    }
}