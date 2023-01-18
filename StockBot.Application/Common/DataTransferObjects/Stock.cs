namespace StockBot.Application.Common.DataTransferObjects;

public class Stock
{
    public string Symbol { get; set; } = default!;
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Open { get; set; } = "N/D";
    public string High { get; set; } = "N/D";
    public string Low { get; set; } = "N/D";
    public string Close { get; set; } = "N/D";
    public int Volume { get; set; }
}