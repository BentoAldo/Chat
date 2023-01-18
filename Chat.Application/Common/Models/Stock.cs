namespace Chat.Application.Common.Models;

public class Stock
{
    public string Symbol { get; set; } = default!;
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Open { get; set; } = default!;
    public string High { get; set; } = default!;
    public string Low { get; set; } = default!;
    public string Close { get; set; } = default!;
    public int Volume { get; set; }
}