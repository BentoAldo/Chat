using Chat.Application.Common.Models;
using Chat.Application.Common.Models.DataTransferObjects;

namespace Chat.Application.Common.Interfaces;

public interface IBotServices
{
    Task<BaseResponse<Stock>?> GetStockAsync(string code);
}