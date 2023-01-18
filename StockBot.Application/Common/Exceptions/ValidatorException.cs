using System.Net;
using StockBot.Domain.Interfaces;

namespace StockBot.Application.Common.Exceptions;

public class ValidatorException : Exception, IServiceException
{
    public ValidatorException(Dictionary<string, object?> extensions)
    {
        Extensions = extensions;
        Extensions.Add("ErrorCode", "VALIDATION_ERROR");
    }

    public string? Detail => null;

    public string Title => "Validation error";

    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public Dictionary<string, object?> Extensions { get; }
}