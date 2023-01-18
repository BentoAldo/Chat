using RabbitMq.Domain.Core.Commands;
using RabbitMq.Domain.Core.Events;

namespace RabbitMq.Domain.Core.Bus;

public interface IEventBus
{
    Task SendCommand<T>(T command) where T : Command;

    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>;
}