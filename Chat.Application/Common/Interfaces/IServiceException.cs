using System.Net;

namespace Chat.Application.Common.Interfaces;

public interface IServiceException
{
    public string Title { get; }

    public string? Detail { get; }

    public HttpStatusCode StatusCode { get; }

    public Dictionary<string, object?> Extensions { get; }
}