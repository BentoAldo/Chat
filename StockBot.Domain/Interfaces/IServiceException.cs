using System.Net;

namespace StockBot.Domain.Interfaces;

public interface IServiceException
{
    public string Title { get; }

    public string? Detail { get; }

    public HttpStatusCode StatusCode { get; }

    public Dictionary<string, object?> Extensions { get; }
}