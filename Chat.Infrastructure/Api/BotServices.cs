using System.Net.Http.Json;
using Chat.Application.Common.Interfaces;
using Chat.Application.Common.Models;
using Chat.Application.Common.Models.DataTransferObjects;

namespace Chat.Infrastructure.Api;

public class BotServices : IBotServices
{
    private readonly HttpClient _httpClient;

    public BotServices(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BaseResponse<Stock>?> GetStockAsync(string code)
    {
        var httpResponseMessage = await _httpClient.GetAsync($"api/v1/stock/{code}");
        return await httpResponseMessage.Content.ReadFromJsonAsync<BaseResponse<Stock>>();
    }
}