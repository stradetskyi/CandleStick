namespace CandleStick.Server.Models.ViewModels
{
    public class CandleStickTreeViewModel
    {
        public DateTime TimeRange { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public long SumVolume { get; set; }
    }
}
