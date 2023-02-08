using StockBot.Domain.MessageBroker.Events;

namespace StockBot.Domain.MessageBroker.Commands;

public abstract class Command : Message
{
    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; protected set; }
}