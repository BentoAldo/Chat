using Chat.Application.Common.Interfaces;
using Chat.Infrastructure.Data;
using Chat.Infrastructure.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        // Declaration of DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString,
                opts => opts.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            
            // Only uncomment this line if you are in development
            options.EnableSensitiveDataLogging();
        });
        
        // Declaration of services
        services.AddTransient<IMessageServices, MessageServices>();
        services.AddTransient<IChatRoomServices, ChatRoomServices>();

        return services;
    }
}