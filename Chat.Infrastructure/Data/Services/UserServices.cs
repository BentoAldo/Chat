using Chat.Application.Common.Interfaces;
using Chat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data.Services;

public class UserServices : IUserServices
{
    private readonly ApplicationDbContext _context;

    public UserServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsers(int maxPageSize)
    {
        return await _context.Users.Take(maxPageSize).ToListAsync();
    }
}