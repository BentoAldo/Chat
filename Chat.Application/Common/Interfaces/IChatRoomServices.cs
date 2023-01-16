using Chat.Domain.Entities;

namespace Chat.Application.Common.Interfaces;

public interface IChatRoomServices
{
    Task<IEnumerable<ChatRoom>> GetChatRoomsAsync(int maxPageSize);
}