using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using StockBot.Application.Common.Interfaces;

namespace StockBot.Infrastructure.External.Services;

public class RabbitMqSender : IRabbitMqSender
{
    public Task SendMessage(object payload)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("BotQueue",
            false,
            false,
            false,
            null);

        var message = JsonConvert.SerializeObject(payload);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("",
            "BotQueue",
            null,
            body);

        return Task.CompletedTask;
    }
}