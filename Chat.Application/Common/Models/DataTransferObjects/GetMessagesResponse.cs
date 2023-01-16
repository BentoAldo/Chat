namespace Chat.Application.Common.Models.DataTransferObjects;

public class GetMessagesResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; } = default!;
    public DateTime Date { get; } = DateTime.Now;
}