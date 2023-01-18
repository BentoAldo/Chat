using StockBot.Application.Common.DataTransferObjects;

namespace StockBot.Application.Common.Interfaces;

public interface IStockServices
{
    Task<BaseResponse<Stock>> GetStockAsync(string code);
}