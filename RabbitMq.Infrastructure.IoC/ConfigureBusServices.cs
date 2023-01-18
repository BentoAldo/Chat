using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMq.Domain.Core.Bus;
using RabbitMq.Infrastructure.Bus;

namespace RabbitMq.Infrastructure.IoC;

public static class ConfigureBusServices
{
    public static IServiceCollection AddBusServices(this IServiceCollection services, IConfiguration configuration)
    {
        //MediatR Mediator
        services.AddMediatR(Assembly.GetExecutingAssembly());

        // Domain Bus
        services.AddSingleton<IEventBus, RabbitMqBus>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            var optionsFactory = sp.GetService<IOptions<RabbitMqSettings>>();
            return new RabbitMqBus(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
        });

        return services;
    }
}