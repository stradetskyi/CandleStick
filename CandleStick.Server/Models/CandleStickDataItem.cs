namespace CandleStick.Server.Models;

public class CandleStickDataItem
{
    public CandleStickDataItem(DateTime time, long quantity, decimal price)
    {
        Time = time;
        Quantity = quantity;
        Price = price;
    }

    public DateTime Time { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}