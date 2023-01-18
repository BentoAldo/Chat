namespace Chat.Application.Common.Models.DataTransferObjects;

public class MessageDto
{
    public int Id { get; set; }

    public string Text { get; set; } = default!;

    public DateTime Date { get; set; }

    public int ChatRoomId { get; set; }

    public string UserId { get; set; } = default!;
}