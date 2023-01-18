using MediatR;

namespace StockBot.Domain.MessageBroker.Events;

public abstract class Message : IRequest<bool>
{
    protected Message()
    {
        MessageType = GetType().Name;
    }

    public string MessageType { get; protected set; }
}