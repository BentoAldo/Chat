using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace StockBot.Application;

public static class ConfigureApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // To support minimal APIS, only for /api/v1/error 
        services.AddEndpointsApiExplorer();

        // We use FastEndpoints instead for Minimal Apis
        services.AddFastEndpoints();

        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = configuration.GetValue<string>("AuthorityUrl");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("StockBotPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "GameSchedulerApi");
            });

            /*options.AddPolicy("GameSchedulerCreateAccountPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope", "GameSchedulerApi.CreateAccount");
                policy.RequireRole("CreateAccount");
            });*/
        });

        services.AddAuthorization();

        // Data Protection
        services.AddDataProtection();

        // Swagger declaration
        services.AddSwaggerDoc(settings =>
        {
            settings.Title = "Stocks Bot API";
            settings.Version = "v1";
            settings.Description = "This API is used to manage the stocks bot";
        });

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