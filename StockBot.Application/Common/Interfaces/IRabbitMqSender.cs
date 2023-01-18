namespace StockBot.Application.Common.Interfaces;

public interface IRabbitMqSender
{
    Task SendMessage(object payload);
}