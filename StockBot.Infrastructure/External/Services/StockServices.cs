using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using StockBot.Application.Common.DataTransferObjects;
using StockBot.Application.Common.Interfaces;

namespace StockBot.Infrastructure.External.Services;

public class StockServices : IStockServices
{
    private readonly HttpClient _httpClient;

    public StockServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BaseResponse<Stock>> GetStockAsync(string code)
    {
        var httpResponseMessage = await _httpClient.GetAsync($"?s={code}&f=sd2t2ohlcv&h&e=csv");

        return new BaseResponse<Stock>
        {
            Success = httpResponseMessage.IsSuccessStatusCode,
            Data = httpResponseMessage.IsSuccessStatusCode ? await GetStockFromFile(httpResponseMessage.Content) : null,
            ProblemDetails = !httpResponseMessage.IsSuccessStatusCode
                ? await httpResponseMessage.Content.ReadFromJsonAsync<ProblemDetails>()
                : null
        };
    }

    private static async Task<Stock> GetStockFromFile(HttpContent content)
    {
        var stockResponse = await content.ReadAsStringAsync();
        var data = stockResponse[(stockResponse.IndexOf(Environment.NewLine, StringComparison.Ordinal) + 1)..];
        var processedData = data.Split(',');
        return new Stock
        {
            Symbol = processedData[0],
            Date = !processedData[1].Contains("N/D")
                ? DateOnly.FromDateTime(Convert.ToDateTime(processedData[1]))
                : default,
            Time = !processedData[2].Contains("N/D")
                ? TimeOnly.FromDateTime(Convert.ToDateTime(processedData[2]))
                : default,
            Open = processedData[3],
            High = processedData[4],
            Low = processedData[5],
            Close = processedData[6],
            Volume = !processedData[7].Contains("N/D") ? Convert.ToInt32(processedData[7]) : default
        };
    }
}