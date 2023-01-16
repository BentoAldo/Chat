using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Message> Messages { get; }
    DbSet<ChatRoom> ChatRooms { get; }
}