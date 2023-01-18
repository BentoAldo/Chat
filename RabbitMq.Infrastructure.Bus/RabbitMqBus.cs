using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMq.Domain.Core.Bus;
using RabbitMq.Domain.Core.Commands;
using RabbitMq.Domain.Core.Events;
using RabbitMq.Infrastructure.Bus;

namespace RabbitMq.Infrastructure;

public class RabbitMqBus : IEventBus
{
    private readonly List<Type> _eventTypes;
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly IMediator _mediator;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly RabbitMqSettings _settings;

    public RabbitMqBus(IMediator mediator, IServiceScopeFactory serviceScopeFactory,
        IOptions<RabbitMqSettings> settings)
    {
        _mediator = mediator;
        _handlers = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
        _settings = settings.Value;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task SendCommand<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            UserName = _settings.UserName,
            Password = _settings.Password
        };

        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        var eventName = @event.GetType().Name;
        channel.QueueDeclare(eventName, false, false, false, null);
        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish("", eventName, null, body);
    }

    public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
    {
        var eventName = typeof(T).Name;
        var handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T))) _eventTypes.Add(typeof(T));

        if (!_handlers.ContainsKey(eventName)) _handlers.Add(eventName, new List<Type>());

        if (_handlers[eventName].Any(s => s == handlerType))
            throw new ArgumentException($"The exception Handler {handlerType.Name} was " +
                                        $"already registered by '{eventName}'", nameof(handlerType));

        _handlers[eventName].Add(handlerType);

        StartBasicConsumer<T>();
    }

    private void StartBasicConsumer<T>() where T : Event
    {
        var factory = new ConnectionFactory
        {
            HostName = _settings.HostName,
            UserName = _settings.UserName,
            Password = _settings.Password,
            DispatchConsumersAsync = true
        };

        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        var eventName = typeof(T).Name;

        channel.QueueDeclare(eventName, false, false, false, null);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.Received += Consumer_Received;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        var eventName = e.RoutingKey;
        var message = Encoding.UTF8.GetString(e.Body.Span);

        try
        {
            await ProcessEvent(eventName, message).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var subscriptions = _handlers[eventName];

                foreach (var subscription in subscriptions)
                {
                    var handler = scope.ServiceProvider.GetService(subscription);
                    if (handler == null) continue;
                    var eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                    var @event = JsonConvert.DeserializeObject(message, eventType!);
                    var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType!);

                    await (Task)concreteType.GetMethod("Handle")?.Invoke(handler, new[] { @event });
                }
            }
    }
}