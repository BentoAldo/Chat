namespace Chat.Domain.Entities;

public class Message
{
    public int Id { get; set; }

    public string Text { get; set; } = default!;

    public DateTime Date { get; set; }

    public int ChatRoomId { get; set; }

    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }
}