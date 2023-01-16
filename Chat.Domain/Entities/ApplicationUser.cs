using Microsoft.AspNetCore.Identity;

namespace Chat.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public IEnumerable<ChatRoom>? ChatRooms { get; set; }
}