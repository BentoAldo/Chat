using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockBot.Application.Common.Interfaces;
using StockBot.Infrastructure.External.Services;

namespace StockBot.Infrastructure;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpClient<IStockServices, StockServices>("ApiClient",
            c => { c.BaseAddress = new Uri(GetBaseApiUrl(configuration)); });

        return services;
    }

    private static string GetBaseApiUrl(IConfiguration configuration)
    {
        var baseApiUrl = configuration["StocksApiBaseUrl"];
        ArgumentNullException.ThrowIfNull(baseApiUrl);
        return baseApiUrl;
    }
}