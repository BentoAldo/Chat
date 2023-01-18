using Chat.Application.Common.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data.Services;

public class MessageServices : IMessageServices
{
    private readonly ApplicationDbContext _context;

    public MessageServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Message>> GetMessagesAsync(int chatRoomId, int maxPageSize = 50)
    {
        return await _context.Messages.Where(m => m.ChatRoomId == chatRoomId).OrderByDescending(m => m.Date)
            .Take(maxPageSize).OrderBy(m => m.Date).ToListAsync();
    }

    public async Task AddMessageAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
    }
}