using Chat.Domain.Entities;

namespace Chat.Application.Common.Interfaces;

public interface IUserServices
{
    Task<IEnumerable<ApplicationUser>> GetUsers(int maxPageSize);
}