using StockBot.Domain.MessageBroker.Commands;
using StockBot.Domain.MessageBroker.Events;

namespace StockBot.Domain.MessageBroker.Bus;

public interface IEventBus
{
    Task SendCommand<T>(T command) where T : Command;

    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>;
}