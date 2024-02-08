namespace CandleStick.Server.Models
{
    public class CandleStickTreeItem
    {
        public DateTime TimeRange { get; set; }
        public List<CandleStickDataItem?> ListDataGroup { get; set; } = new();

        public int Count => ListDataGroup.Count;
        public CandleStickDataItem? Open => ListDataGroup.FirstOrDefault();
        public CandleStickDataItem? Close => ListDataGroup.LastOrDefault();
        public CandleStickDataItem? High => ListDataGroup.MaxBy(i => i.Price);
        public CandleStickDataItem? Low => ListDataGroup.MinBy(i => i.Price);
        public long SumVolume => ListDataGroup.Sum(i => i.Quantity);
    }
}
