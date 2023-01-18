namespace Chat.Domain.Entities;

public class ChatRoom
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    public ICollection<ApplicationUser>? Users { get; set; }

    public ICollection<Message>? Messages { get; set; }
}