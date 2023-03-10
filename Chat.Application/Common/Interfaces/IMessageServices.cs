using Chat.Domain.Entities;

namespace Chat.Application.Common.Interfaces;

public interface IMessageServices
{
    Task<IEnumerable<Message>> GetMessagesAsync(int chatRoomId, int maxPageSize = 50);

    Task AddMessageAsync(Message message);
}