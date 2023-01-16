using Chat.Application.Common.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data.Services;

public class ChatRoomServices : IChatRoomServices
{
    private readonly ApplicationDbContext _context;

    public ChatRoomServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ChatRoom>> GetChatRoomsAsync(int maxPageSize = 10)
    {
        return await _context.ChatRooms.OrderBy(m => m.CreatedAt).Take(maxPageSize).ToListAsync();
    }
}