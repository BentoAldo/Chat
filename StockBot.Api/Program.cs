using Serilog;
using System.Text.Json;
using System.Text.Json.Serialization;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Diagnostics;
using StockBot.Application;
using StockBot.Application.Common.Errors;
using StockBot.Domain.Interfaces;
using StockBot.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 401) logger.Warning("Unauthorized request");
});

app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler("/api/v1/error");
app.UseFastEndpoints(c =>
{
    c.Serializer.Options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    c.Endpoints.RoutePrefix = "api";
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(s => s.ConfigureDefaults());
}

app.Map("/api/v1/error", (HttpContext httpContext) =>
{
    var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    var (statusCode, title, detail, extensions) = exception switch
    {
        JsonException jsonException => Errors.ParsingFailedDetails(jsonException),
        IServiceException serviceException => Errors.ServiceExceptionDetails(serviceException),
        _ => Errors.UnhandledExceptionDetails()
    };

    return Results.Problem(statusCode: statusCode, title: title, detail: detail, extensions: extensions);
});

app.Run();