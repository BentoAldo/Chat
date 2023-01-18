namespace StockBot.Domain.MessageBroker.Events;

public abstract class Event
{
    protected Event()
    {
        Timestamp = DateTime.Now;
    }

    public DateTime Timestamp { get; protected set; }
}