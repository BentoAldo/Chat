namespace Chat.Application.Common.Models;

public class Stock
{
    public string Symbol { get; set; } = default!;
    public DateTime Date { get; set; }
    public DateTime Time { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
    public int Volume { get; set; }
}