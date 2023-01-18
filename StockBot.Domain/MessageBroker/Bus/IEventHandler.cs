using StockBot.Domain.MessageBroker.Events;

namespace StockBot.Domain.MessageBroker.Bus;

public interface IEventHandler<in TEvent> : IEventHandler
    where TEvent : Event
{
    Task Handle(TEvent @event);
}

public interface IEventHandler
{
}