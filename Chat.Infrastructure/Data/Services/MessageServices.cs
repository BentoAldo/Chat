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
    
    public async Task<IEnumerable<Message>> GetMessagesAsync(int maxPageSize = 50)
    {
        return await _context.Messages.OrderBy(m => m.Date).Take(maxPageSize).ToListAsync();
    }
}