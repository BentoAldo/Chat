using System.Net;
using System.Text.Json;
using StockBot.Domain.Interfaces;

namespace StockBot.Application.Common.Errors;

public static class Errors
{
    public static (int, string?, string?, Dictionary<string, object?>) ParsingFailedDetails(JsonException jsonException)
    {
        return ((int)HttpStatusCode.BadRequest, "There was an error parsing your request", jsonException.Message,
            new Dictionary<string, object?> { { "path", jsonException.Path }, { "ErrorCode", "PARSING_ERROR" } });
    }

    public static (int, string?, string?, Dictionary<string, object?>) ServiceExceptionDetails(
        IServiceException serviceException)
    {
        return ((int)serviceException.StatusCode, serviceException.Title, serviceException.Detail,
            serviceException.Extensions);
    }

    public static (int, string?, string?, Dictionary<string, object?>) UnhandledExceptionDetails()
    {
        return ((int)HttpStatusCode.InternalServerError, "Internal Server Error",
            "The server encountered an unhandled exception and was not able to fulfill your request",
            new Dictionary<string, object?>());
    }
}