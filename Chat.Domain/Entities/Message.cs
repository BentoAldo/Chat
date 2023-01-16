namespace Chat.Domain.Entities;

public class Message
{
    public int Id { get; set; }

    public string Text { get; set; } = default!;
    
    public DateTime Date { get; } = DateTime.Now;
    
    public string UserId { get; set; } = default!;
    
    public ApplicationUser? User { get; set; }
}