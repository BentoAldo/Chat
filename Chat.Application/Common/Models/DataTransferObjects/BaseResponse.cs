using Microsoft.AspNetCore.Mvc;

namespace Chat.Application.Common.Models.DataTransferObjects;

public class BaseResponse<T> where T : class
{
    public bool Success { get; set; }

    public T? Data { get; set; }
    
    public ProblemDetails? ProblemDetails { get; set; }
}