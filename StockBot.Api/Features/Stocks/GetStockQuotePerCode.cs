using FastEndpoints;
using StockBot.Application.Common.DataTransferObjects;
using StockBot.Application.Common.Interfaces;
using static StockBot.Api.Utils.ValidationUtils;

namespace StockBot.Api.Features.Stocks;

public class GetStockQuotePerCode : EndpointWithoutRequest<BaseResponse<Stock>>
{
    private readonly IStockServices _stockServices;

    public GetStockQuotePerCode(IStockServices stockServices)
    {
        _stockServices = stockServices;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var code = Route<string>("code");
        Response = await _stockServices.GetStockAsync(code!);
        await SendAsync(Response, !Response.Success ? Response.ProblemDetails?.Status ?? 500 : 200, cancellation: ct);
    }

    public override void OnValidationFailed()
    {
        OnAfterValidation(ValidationFailed, ValidationFailures);
    }

    public override void Configure()
    {
        Get("v1/stock/{code}");
        Policies("StockBotPolicy");
        AllowAnonymous();
        DontCatchExceptions();
        Summary(s =>
        {
            s.Summary = "Get Stocks per code";
            s.Description = "This endpoint is used to get stocks per code";
        });
    }
}